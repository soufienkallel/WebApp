using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using BCrypt.Net;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly AppkicationContext context;

        public UserController(AppkicationContext context)
        {
            this.context = context;
        }

        public ActionResult Signup()
        {

            return View();
        }



        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(User user)
        {
            // Validate user input (customize as needed)
            if (ModelState.IsValid)
            {
                if (context.Users
                        .Where(x => x.UserEmail == user.UserEmail)
                        .Count() > 0)
                {
                    ViewBag.SomeData = "Some string data";
                    return View("Signup", "User");
                }

                // Hash the password before saving to the database
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.UserPassw);
                user.UserPassw = hashedPassword;

                User u = new User();
                u.UserID = user.UserID;
                u.UserName = user.UserName;
                u.UserEmail = user.UserEmail;
                u.UserPassw = user.UserPassw;
                u.UserRole = "user";
                context.Users.Add(u);
                context.SaveChanges();

                return RedirectToAction("Index", "Film");
            }

            // If validation fails, return to the signup view
            ViewBag.SomeData = new User();
            return View(user);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = context.Users.SingleOrDefault(u => u.UserEmail == user.UserEmail);

                if (existingUser != null && BCrypt.Net.BCrypt.Verify(user.UserPassw, existingUser.UserPassw))
                {
                    // Authentication successful
                    // You can set authentication cookies or redirect to the desired page
                    // For simplicity, let's just redirect to the Index action of the Film controller
                    return RedirectToAction("Index", "Film");
                }

                // Authentication failed
                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }

            // If validation fails, return to the login view
            return View(user);
        }

    }
}
