using Microsoft.AspNetCore.Mvc;

namespace Saidality.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index(){
            
return View();
        }
    }
}