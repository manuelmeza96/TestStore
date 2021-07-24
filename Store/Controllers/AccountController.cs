namespace Store.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Store.Business;
    using Store.Models;

    public class AccountController : Controller
    {
        private Security security = new Security();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            AccountModel accountModel = new AccountModel();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || accountModel.login(username, password) == null)
            {
                ViewBag.error = "Invalid";
                return View("Index");
            }
            else
            {
                security.SignIn(this.HttpContext, accountModel.find(username));
                return RedirectToAction("Index", "/Admin");
            }
        }

        public IActionResult Welcome()
        {
            return RedirectToAction("Index","Admin");
        }

        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public IActionResult SignOut()
        {
            security.SignOut(this.HttpContext);
            return RedirectToAction("Index");
        }
    }
}
