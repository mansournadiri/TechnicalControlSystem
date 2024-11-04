using Application.Feature.Auth.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.AppMetaData;
using WebAPI.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    public class AuthController : AppBaseController
    {
        // GET: api/<LoginController>
        [HttpPost]
        [Route(Router.AuthRouting.Actions.Login)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            LoginViewModel command = new LoginViewModel(request.email, request.password);
            var response = await Mediator.Send(command);
            return CustomResult(response);
        }
        [HttpPost]
        [Route(Router.AuthRouting.Actions.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel request)
        {
            RegisterViewModel command = new RegisterViewModel()
            {
                email = request.email,
                firstName = request.firstName,
                lastName = request.lastName,
                mobileNumber = request.mobileNumber,
                password = request.password
            };
            var response = await Mediator.Send(command);
            return CustomResult(response);
        }
    }
}
