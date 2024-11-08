using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
using Application.Model;
using Application.Persistence.Interface;
using Application.Persistence.Interface.IEntity;
using Common.Interface;
using Domain.AppMetaData;
using Domain.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Persistence.Repo.EntityService
{
    public class UserService : IUserService
    {
        private readonly BaseResponseHandler _baseResponseHandler;
        private readonly IBaseRepo<User> _baseRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommon _common;
        private readonly JwtSettings _jwtSettings;
        public UserService(
            IBaseRepo<User> baseRepo, 
            IUnitOfWork unitOfWork, 
            ICommon common,
            IOptions<JwtSettings> jwtSettings)
        {
            _baseResponseHandler = new BaseResponseHandler();
            _baseRepo = baseRepo;
            _unitOfWork = unitOfWork;
            _common = common;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<BaseResponse<LoginResponse>> Login(LoginViewModel request)
        {
            var user = await _baseRepo.FindAsync(x => x.UserName == request.email);
            if (user == null)
            {
                return _baseResponseHandler.NotFound<LoginResponse>("UserNotFound");
            }
            request.password = _common.GenerateHashKey(request.password);
            var result = (user.Password == request.password) ? true : false;
            if (!result)
            {
                return _baseResponseHandler.NotFound<LoginResponse>("InvalidCredentials");
            }
            SecurityTokenDescriptor jwtSecurityTokenDescriptor = await GenerateToken(user);
            JwtSecurityTokenHandler tokenHandler = new();
            var securityToken = tokenHandler.CreateToken(jwtSecurityTokenDescriptor);
            LoginResponse response = new LoginResponse
            {
                UserId = user.UserId,
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Email = user.UserName,
                UserName = user.UserName,
                guid = user.guid
            };
            return _baseResponseHandler.Success(response, null);
        }

        public async Task<BaseResponse<RegisterResponse>> Regiter(RegisterViewModel request)
        {
            var exist = await _baseRepo.IsExistAsync(x => x.UserName == request.nationalID);
            if (exist)
            {
                return _baseResponseHandler.Conflict<RegisterResponse>("کاربر قبلاً در سیستم تعریف شده است.");
            }
            User _user = new User();
            _user.UserId = _baseRepo.MaxKey(x => x.UserId);
            _user.UserName = request.nationalID;
            //_user.PartyRef = request.partyRef.Value;
            var user = await _baseRepo.AddAsync(_user);
            var numberRowInserted = _unitOfWork.SaveChanges();
            if (numberRowInserted > 0)
            {
                RegisterResponse _registerResponse = new RegisterResponse();
                _registerResponse.UserId = user.UserId;
                _registerResponse.guid = user.guid;
                return _baseResponseHandler.Success<RegisterResponse>(_registerResponse, null);
            }
            else
                return _baseResponseHandler.BadRequest<RegisterResponse>("CanNotCreateUser", new());
        }

        public Task<string> ResetPassword(ResetPasswordViewModel request)
        {
            throw new NotImplementedException();
        }

        public Task<string> SendResetPassword(SendResetPasswordViewModel request)
        {
            throw new NotImplementedException();
        }

        private async Task<SecurityTokenDescriptor> GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, value:user.UserName??string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(CustomClaimTypes.guid, user.guid.ToString())
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.EncryptionKey));
            var encryptionCredential = new EncryptingCredentials(symmetricSecurityKey, SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            //var jwtSecurityToken = new JwtSecurityToken(
            //    issuer: _jwtSettings.Issuer,
            //    audience: _jwtSettings.Audience,
            //    claims: claims,
            //    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            //    signingCredentials: signingCredentials
            //    );
            var jwtSecurityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Audience = _jwtSettings.Audience,
                Issuer = _jwtSettings.Issuer,
                Expires = DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                NotBefore = DateTime.Now,
                IssuedAt = DateTime.Now,
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptionCredential,
                CompressionAlgorithm = CompressionAlgorithms.Deflate
            };
            return jwtSecurityTokenDescriptor;
        }
    }
}
