using FirstCoreMVCWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Initialize the User model and pass it to the view
            var model = new User();
            ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
            ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create([FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
                ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
                return View(user);
            }
            // Process the Model, i.e., Save user to database
            // Redirect to another action after successful operation
            return RedirectToAction("Success", user);
        }
        [HttpGet]
        public IActionResult Success(User user)
        {
            return View(user);
        }


        //[HttpPost]
        //public IActionResult Create(
        //    [FromForm(Name = "Name")] string UserName,
        //    [FromForm(Name = "Email")] string UserEmail,
        //    [FromForm] string Password,
        //    [FromForm] string Mobile,
        //    [FromForm] string Gender,
        //    [FromForm] string Country,
        //    [FromForm] List<string> Hobbies,
        //    [FromForm] DateTime? DateOfBirth,
        //    [FromForm] bool TermsAccepted)
        //{
        //    var user = new User
        //    {
        //        UserName = UserName,
        //        UserEmail = UserEmail,
        //        Password = Password,
        //        Mobile = Mobile,
        //        Gender = Gender,
        //        Country = Country,
        //        Hobbies = Hobbies,
        //        DateOfBirth = DateOfBirth,
        //        TermsAccepted = TermsAccepted
        //    };
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
        //        ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
        //        return View(user);
        //    }
        //    // Process the Model, i.e., Save user to database
        //    return RedirectToAction("Success", user);
        //}


    }
}
