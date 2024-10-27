using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers
{
    public class TestController : Controller
    {
        static int a = 0;
        public IActionResult Showbutton()
        {
            //++a;
            return View();
        }
        public IActionResult ClickButton()
        {
            ++a;
            return View("Showbutton", a);
        }
    }
}
