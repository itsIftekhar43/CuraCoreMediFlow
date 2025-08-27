using Microsoft.AspNetCore.Mvc;

namespace CuraCoreMediFlow.ApiService.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
