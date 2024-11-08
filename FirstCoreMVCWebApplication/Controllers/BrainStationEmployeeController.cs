using FirstCoreMVCWebApplication.Data;
using FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class BrainStationEmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BrainStationEmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new EmployeeViewModel();

            await PoPulateViewModelAsync(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Map ViewModel to Model
                    var employee = new Employee
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        DateOfBirth = model.DateOfBirth,
                        JoiningDate = model.JoiningDate,
                        Gender = model.Gender.Value,
                        Password = model.Password,

                        // Job Details
                        JobDetail = new JobDetail
                        {
                            JobTitleId = model.SelectedJobTitleId,
                            DepartmentId = model.DepartmentId,
                            Salary = model.Salary
                        },
                        // Address
                        Address = new Address
                        {
                            Street = model.Street,
                            City = model.City,
                            State = model.State,
                            PostalCode = model.PostalCode
                        },
                        // Skills
                        SkillSets = new List<SkillSet>()
                    };
                    // Adding Skills
                    if (model.SkillSetIds != null)
                    {
                        foreach (var skillId in model.SkillSetIds)
                        {
                            employee.SkillSets.Add(new SkillSet
                            {
                                SkillSetId = skillId
                            });
                        }
                    }
                    // Attach selected skills
                    if (model.SkillSetIds != null && model.SkillSetIds.Any())
                    {
                        // Fetch the selected skills from the database
                        var selectedSkills = await _context.SkillSets
                            .Where(s => model.SkillSetIds.Contains(s.SkillSetId))
                            .ToListAsync();
                        // Assign to the Employee's SkillSets
                        employee.SkillSets = selectedSkills;
                    }
                    // Add to DbContext
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    // Redirect to Success page with EmployeeId
                    return RedirectToAction(nameof(Successful), new { id = employee.EmployeeId });
                }
                catch (DbUpdateException ex)
                {
                    // Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists see your system administrator.");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                }
            }
            // If we reach here, something failed; re-populate dropdowns
            await PoPulateViewModelAsync(model);
            return View(model);
        }

        // GET: Employees/Successful
        public async Task<IActionResult> Successful(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Address)
                .Include(e => e.JobDetail)
                    .ThenInclude(jd => jd.JobTitle)
                .Include(e => e.JobDetail)
                    .ThenInclude(jd => jd.Department)
                .Include(e => e.SkillSets)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }



        private async Task PoPulateViewModelAsync(EmployeeViewModel viewModel)
        {
            viewModel.Departments = await _context.Departments
                .AsNoTracking()
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.Name
                }).ToListAsync();

            viewModel.SkillSets = await _context.SkillSets
                .AsNoTracking()
                .Select(x => new SelectListItem
                {
                    Value = x.SkillSetId.ToString(),
                    Text = x.SkillName
                }).ToListAsync();

            viewModel.JobTitles = await _context.JobTitles
                .AsNoTracking()
                .Select(j => new SelectListItem
                {
                    Value = j.JobTitleId.ToString(),
                    Text = j.TitleName
                })
                .ToListAsync();

            viewModel.Genders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

        }
    }
}
