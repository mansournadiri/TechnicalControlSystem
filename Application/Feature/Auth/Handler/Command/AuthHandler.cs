using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
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
        protected IBaseRepo<Party> _partyService;
        public AuthHandler(IUnitOfWork uofw, IMapper mapper, IUserService userService, IBaseRepo<Party> partyService)
        {
            _uofw = uofw;
            _mapper = mapper;
            _userService = userService;
            _partyService = partyService;
        }
        public Task<BaseResponse<LoginResponse>> Handle(LoginViewModel command, CancellationToken cancellationToken)
        {
            return _userService.Login(command);
        }
        public Task<BaseResponse<RegisterResponse>> Handle(RegisterViewModel command, CancellationToken cancellationToken)
        {
            var exist = _partyService.isExist(x => x.CompanyIdentity == command.companyIdentity);
            if (!exist)
            {
                Party _party = new Party();
                _party.PartyId = _partyService.MaxKey(x => x.PartyId);
                _party.CompanyIdentity = command.companyIdentity;
                _party.CompanyName = command.companyName;
                _party.Mobile = command.mobileNumber;
                _party.NationalId = command.nationalID;
                _party = _partyService.Add(_party);
                _uofw.SaveChanges();
                command.partyRef = _party.PartyId;
            }
            else
            {
                var selectParty = _partyService.Find(x => x.CompanyIdentity == command.companyIdentity);
                command.partyRef = selectParty.PartyId;
            }
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
