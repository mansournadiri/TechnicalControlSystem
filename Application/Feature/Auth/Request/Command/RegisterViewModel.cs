using Application.Base;
using Application.Feature.Auth.Result;
using MediatR;

namespace Application.Feature.Auth.Request.Command
{
    public class RegisterViewModel : IRequest<BaseResponse<RegisterResponse>>
    {
        public long? partyRef { get; set; }
        public string? companyName { get; set; }
        public string? companyIdentity { get; set; }
        public string? mobileNumber { get; set; }
        public string? nationalID { get; set; }
    }
}
