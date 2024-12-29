using FirstCoreMVCWebApplication.Models.FormTag;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class FormTagController : Controller
    {
        // Simulated in-memory storage with hardcoded data for demonstration purposes
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                StudentId = 1, FullName = "Pranaya Rout", Password = "Password123!",
                DateOfBirth = new DateTime(1990, 1, 1), Gender = Gender.Male, Address = "Test Address 1234",
                Branch = Branch.CSE, TermsAndConditions = true,
                Hobbies = new List<string> { "Reading", "Traveling" },
                Skills = new List<string> { "C#", "SQL" }
            },
            new Student
            {
                StudentId = 2, FullName = "Hina Sharma", Password = "Password123!",
                DateOfBirth = new DateTime(1992, 2, 15), Gender = Gender.Female, Address = "Test Address 1234",
                Branch = Branch.ETC, TermsAndConditions = true,
                Hobbies = new List<string> { "Music", "Traveling" },
                Skills = new List<string> { "Python", "Machine Learning" }
            },
            new Student
            {
                StudentId = 3, FullName = "Anurag Mohanty", Password = "Password123!",
                DateOfBirth = new DateTime(1988, 11, 23), Gender = Gender.Male, Address = "Test Address 1234",
                Branch = Branch.Mechanical, TermsAndConditions = true,
                Hobbies = new List<string> { "Reading", "Music" },
                Skills = new List<string> { "ASP.NET Core", "Oracle" }
            }
        };
        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // Find the student by Id
            var student = students.FirstOrDefault(std => std.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            // Return the student details view
            return View(student);
        }

        [HttpGet]
        public IActionResult Register()
        {
            // Ensure the Hobbies list is initialized
            var student = new Student
            {
                Hobbies = new List<string>()  // Initialize to prevent null reference issues
            };
            // Pass the list of available hobbies and skills to the view
            ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Music", "Sports", "Photography" };
            ViewBag.Skills = new List<string> { "C#", "Python", "SQL", "Machine Learning", "ASP.NET Core", "Oracle", "Data Analysis" };
            return View(student);
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                //Generated the Student Id
                student.StudentId = students.Count() + 1;
                // Add the student to the list
                students.Add(student);
                // Redirect to the List page after successful registration
                return RedirectToAction("List");
            }
            // Pass the list of available hobbies and skills back to the view in case of errors
            ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Music", "Sports", "Photography" };
            ViewBag.Skills = new List<string> { "C#", "Python", "SQL", "Machine Learning", "Physics", "Research", "Data Analysis" };
            // If invalid, return the same view with validation messages
            return View(student);
        }
    }
}
