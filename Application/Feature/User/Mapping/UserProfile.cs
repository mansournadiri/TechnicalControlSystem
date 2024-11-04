using Application.Feature.User.Request.Command;
using AutoMapper;
using Domain.Entity;

namespace Application.Feature.User.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserViewModel, Domain.Entity.User>().ReverseMap();
            CreateMap<EditUserViewModel, Domain.Entity.User>();
        }
    }
}
