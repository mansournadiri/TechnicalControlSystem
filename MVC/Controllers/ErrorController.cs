using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult notFound404()
        {
            return View();
        }
    }
}
