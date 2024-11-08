using Application.Base;
using Application.Feature.Auth.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Auth.Request.Command
{
    public class ConfirmLoginViewModel : IRequest<BaseResponse<LoginResponse>>
    {
        public Guid guid { get; set; }
        public string jwtToken { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
    }
}
