using Application.Feature.Auth.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.AppMetaData;
using WebAPI.Base;
using Microsoft.AspNetCore.Authorization;

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
                companyIdentity = request.companyIdentity,
                companyName = request.companyName,
                nationalID = request.nationalID,
                mobileNumber = request.mobileNumber
            };
            var response = await Mediator.Send(command);
            return CustomResult(response);
        }

        [Authorize]
        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult GetValue(string someThings)
        {
            return Ok(StatusCodes.Status200OK);
        }
    }
}
