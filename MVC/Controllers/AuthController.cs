using Application.Feature.Auth.Request.Command;
using Domain.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        protected readonly ISender _sender;
        protected readonly IHttpContextAccessor _contextAccessor;
        public AuthController(ISender sender, IHttpContextAccessor contextAccessor)
        {
            _sender = sender;
            _contextAccessor = contextAccessor;
        }
        public IActionResult Login()
        {
            ViewData["Title"] = "ورود";
            return View();
        }
        public IActionResult Forget()
        {
            ViewData["Title"] = "فراموشی رمز عبور";
            return View();
        }
        public IActionResult Register()
        {
            ViewData["Title"] = "ثبت نام";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel request, bool? baseResponse = false)
        {
            ViewData["Title"] = "ثبت نام";
            var response = await _sender.Send(request);
            if (response.Succeeded == true)
            {
                Response.Cookies.Append(CustomClaimTypes.XAccessToken, response.Data?.jwtToken ?? string.Empty, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict});
                Response.Cookies.Append(CustomClaimTypes.guid, response.Data?.guid.ToString() ?? string.Empty, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict });
                return RedirectToAction("ConfirmLogin");
            }
            ViewBag.response = response;
            return View();
        }
        [HttpGet]
        public IActionResult ConfirmLogin()
        {
            ViewData["Title"] = "کد اعتبارسنجی";
            var jwtToken = _contextAccessor.HttpContext?.Request.Cookies[CustomClaimTypes.XAccessToken] ?? string.Empty;
            var guid = _contextAccessor.HttpContext?.Request.Cookies[CustomClaimTypes.guid] ?? string.Empty;
            if (string.IsNullOrWhiteSpace(jwtToken))
                return Redirect("/notFound404");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmLogin(string code)
        {
            var jwtToken = _contextAccessor.HttpContext?.Request.Cookies[CustomClaimTypes.XAccessToken] ?? string.Empty;
            var guid = _contextAccessor.HttpContext?.Request.Cookies[CustomClaimTypes.guid] ?? string.Empty;
            ConfirmLoginViewModel request = new ConfirmLoginViewModel();
            request.guid = Guid.Parse(guid);
            request.code = code;
            request.jwtToken = jwtToken;
            var response = await _sender.Send(request);
            return View();
        }
    }
}
