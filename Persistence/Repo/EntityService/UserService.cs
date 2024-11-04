using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
using Application.Persistence.Interface;
using Application.Persistence.Interface.IEntity;
using Domain.Entity;

namespace Persistence.Repo.EntityService
{
    public class UserService : IUserService
    {
        //private readonly JwtSettings _jwtSettings;
        private readonly BaseResponseHandler _baseResponseHandler;
        private readonly IBaseRepo<User> _baseRepo;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IBaseRepo<User> baseRepo, IUnitOfWork unitOfWork)
        {
            _baseResponseHandler = new BaseResponseHandler();
            _baseRepo = baseRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<LoginResponse>> Login(LoginViewModel request)
        {
            var user = await _baseRepo.FindAsync(x => x.UserName == request.email);
            if (user == null)
            {
                return _baseResponseHandler.NotFound<LoginResponse>("UserNotFound");
            }
            var result = (user.Password == request.password) ? true : false;
            if (!result)
            {
                return _baseResponseHandler.NotFound<LoginResponse>("InvalidCredentials");
            }
            //JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            LoginResponse response = new LoginResponse
            {
                UserId = user.UserId,
                //Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.UserName,
                UserName = user.UserName,
                guid = user.guid
            };
            return _baseResponseHandler.Success(response, null);
        }

        public async Task<BaseResponse<RegisterResponse>> Regiter(RegisterViewModel request)
        {
            var exist = await _baseRepo.IsExistAsync(x => x.UserName == request.email);
            if (exist)
            {
                return _baseResponseHandler.Conflict<RegisterResponse>("UserDuplicated");
            }
            User _user = new User();
            _user.UserId = _baseRepo.MaxKey(x => x.UserId);
            _user.UserName = request.email;
            _user.Password = request.password;
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

        //private async Task<JwtSecurityToken> GenerateToken(User user)
        //{
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.AppBearerToken),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Email, user.Password),
        //        new Claim(CustomClaimTypes.Uid, user.CookieData)
        //    };

        //    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        //    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        //    var jwtSecurityToken = new JwtSecurityToken(
        //        issuer: _jwtSettings.Issuer,
        //        audience: _jwtSettings.Audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInDays),
        //        signingCredentials: signingCredentials);
        //    return jwtSecurityToken;
        //}
    }
}
