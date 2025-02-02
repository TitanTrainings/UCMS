using Microsoft.AspNetCore.Mvc;
using UCMS.Website.Models;
using UCMS.Website.Services;

namespace UCMS.Website.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;

        public AuthenticationController(IConfiguration configuration,
            IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        { 
            // check if the user exists with the given username and password from the User table in db.
            var loginuser = _userService.GetUserByUsernameAndPassword(user);
            if (loginuser != null)
            {
                HttpContext.Session.SetString("Username", user.Username);

                HttpContext.Session.SetString("Role", user.RoleId.ToString());

                if (loginuser.RoleId == 2 || loginuser.RoleId == 3)
                {
                    return RedirectToAction("Index", "Faculties");
                }
                else if (loginuser.RoleId == 1)
                {
                    return RedirectToAction("Index", "Students");
                }
            }

            //if the username or password is wrong or the user does not exist
            ViewBag.Error = "Invalid login credentials.";

            return View();            
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
