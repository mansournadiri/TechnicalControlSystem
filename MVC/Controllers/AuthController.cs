﻿using Application.Feature.Auth.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        protected readonly ISender _sender;
        public AuthController(ISender sender)
        {
            _sender = sender;
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
            RegisterViewModel command = new RegisterViewModel()
            {
                companyIdentity = request.companyIdentity,
                companyName = request.companyName,
                nationalID = request.nationalID,
                mobileNumber = request.mobileNumber
            };
            var response = await _sender.Send(command);
            return Ok(response);
        }
    }
}
