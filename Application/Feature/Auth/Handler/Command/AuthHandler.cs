using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
using Application.Persistence.Interface;
using Application.Persistence.Interface.IEntity;
using AutoMapper;
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
        public AuthHandler(IUnitOfWork uofw, IMapper mapper, IUserService userService)
        {
            _uofw = uofw;
            _mapper = mapper;
            _userService = userService;
        }
        public Task<BaseResponse<LoginResponse>> Handle(LoginViewModel command, CancellationToken cancellationToken)
        {
            return _userService.Login(command);
        }
        public Task<BaseResponse<RegisterResponse>> Handle(RegisterViewModel command, CancellationToken cancellationToken)
        {
            return _userService.Regiter(command);
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
