using FirstCoreMVCWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudentDetails(int id)
        {
            var studentDetails = _studentRepository.GetStudentById(id);
            return Json(studentDetails);
        }
    }
}
