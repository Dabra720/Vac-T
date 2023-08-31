using Microsoft.AspNetCore.Mvc;

namespace Vac_T.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
