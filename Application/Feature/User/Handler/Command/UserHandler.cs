using Application.Feature.User.Request.Command;
using Application.Persistence.Interface;
using Application.Persistence.Interface.IEntity;
using AutoMapper;
using MediatR;
using Domain.Entity;

namespace Application.Feature.User.Handler.Command
{
    public class UserHandler : 
        IRequestHandler<CreateUserViewModel, bool>, 
        IRequestHandler<EditUserViewModel, bool>
    {
        protected IUnitOfWork _uofw;
        protected IMapper _mapper;
        protected IUserService _userService;
        protected IBaseRepo<Domain.Entity.User> _BaseRepo;
        public UserHandler(IUnitOfWork uofw, 
            IMapper mapper, 
            IUserService userService,
            IBaseRepo<Domain.Entity.User> baseRepo
            )
        {
            _uofw = uofw;
            _mapper = mapper;
            _userService = userService;
            _BaseRepo = baseRepo;
        }

        public Task<bool> Handle(CreateUserViewModel command, CancellationToken cancellationToken)
        {
            bool resultAction = false;
            try
            {
                var _mappingData = _mapper.Map<Domain.Entity.User>(command);
                Domain.Entity.User _user = new Domain.Entity.User()
                {
                    PartyRef = command.PartyRef,
                    Password = command.Password
                };
                _user = _BaseRepo.Add(_user);
                var numberOfInsertedRow = _uofw.SaveChanges();
                resultAction = (numberOfInsertedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error happened {ex.ToString()}");
            }
            return Task.FromResult(resultAction);
        }
        public Task<bool> Handle(EditUserViewModel command, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
