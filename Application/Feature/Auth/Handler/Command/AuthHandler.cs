using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
using Application.Feature.Auth.Validatior;
using Application.Persistence.Interface;
using Application.Persistence.Interface.IEntity;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Feature.Auth.Handler.Command
{
    public class AuthHandler : 
        IRequestHandler<LoginViewModel, BaseResponse<LoginResponse>>,
        IRequestHandler<RegisterViewModel, BaseResponse<RegisterResponse>>,
        IRequestHandler<ResetPasswordViewModel, string>,
        IRequestHandler<SendResetPasswordViewModel, string>
    {
        protected IUnitOfWork _uofw;
        protected IMapper _mapper;
        protected IUserService _userService;
        protected IPartyService _partyService;
        protected BaseResponseHandler _baseResponseHandler;
        public AuthHandler(IUnitOfWork uofw, IMapper mapper, IUserService userService, IPartyService partyService)
        {
            _uofw = uofw;
            _mapper = mapper;
            _userService = userService;
            _partyService = partyService;
            _baseResponseHandler = new BaseResponseHandler();
        }
        public Task<BaseResponse<LoginResponse>> Handle(LoginViewModel command, CancellationToken cancellationToken)
        {
            return _userService.Login(command);
        }
        public async Task<BaseResponse<RegisterResponse>> Handle(RegisterViewModel command, CancellationToken cancellationToken)
        {
            RegisterValidation validation = new RegisterValidation(command);
            var response = await validation.CheckValidation(cancellationToken);
            if (response.Succeeded == true)
            {
                long partyRef = await _partyService.Regiter(command);
                if (partyRef > 0)
                    return await _userService.Regiter(command);
                else
                    return new BaseResponse<RegisterResponse>() { Succeeded = false, Message = "خطا در ایجاد حساب کاربری، لطفاً مجدداً اقدام نمایید." };
            }
            else
                return new BaseResponse<RegisterResponse>() { Succeeded = false, Message = response.Message };
        }
        public Task<string> Handle(ResetPasswordViewModel command, CancellationToken cancellationToken)
        {
            return _userService.ResetPassword(command);
        }
        public Task<string> Handle(SendResetPasswordViewModel command, CancellationToken cancellation)
        {
            return _userService.SendResetPassword(command);
        }
    }
}
