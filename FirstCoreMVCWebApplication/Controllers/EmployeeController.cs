using FirstCoreMVCWebApplication.Models.ValidationPractice;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        //Handles the form submission for creating a new employee.
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            // Check if the submitted model passes all validation rules
            if (ModelState.IsValid)
            {
                // TODO: Save the employee data to the database
                // Redirect to the Successful action upon successful creation
                return RedirectToAction("Successful");
            }
            // If validation fails, redisplay the form with validation errors
            return View(employee);
        }
        // Displays a success message after employee creation.
        public IActionResult Successful()
        {
            return View();
        }
    }
}
