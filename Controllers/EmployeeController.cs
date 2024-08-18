using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Using_GenericRepository_CrudOperation.Models;
using Using_GenericRepository_CrudOperation.Repository;

namespace Using_GenericRepository_CrudOperation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenericRepository<tblEmployee> genericRepository;

        public EmployeeController(IGenericRepository<tblEmployee> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<tblEmployee> employees = await genericRepository.GetAllAsync();
            return View(employees);
        }

        public async Task<IActionResult> AddEmployee(int? id)
        {
            if (id == null)
            {
                return View(new tblEmployee());
            }
            else
            {
                tblEmployee employee = await genericRepository.GetByIdAsync(id.Value);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddEmployee(tblEmployee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Id == 0)
                    {
                        await genericRepository.AddAsync(model);
                        TempData["success"] = "Employee added successfully.";
                    }
                    else
                    {
                        await genericRepository.UpdateAsync(model);
                        TempData["success"] = "Employee updated successfully.";
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["error"] = model.Id == 0 ? "Error occourd while adding employee." : "Error occourd while updating employee.";
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                tblEmployee employee = await genericRepository.GetByIdAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                await genericRepository.DeleteAsync(id);
                TempData["success"] = "Employee deleted successfully";
            }
            catch (Exception)
            {
                TempData["error"] = "Error occurred while deleting employee";
            }
            return RedirectToAction("Index");
        }
    }
}
