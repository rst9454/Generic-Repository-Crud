using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Using_GenericRepository_CrudOperation.GenericSerivce;
using Using_GenericRepository_CrudOperation.Models;
using Using_GenericRepository_CrudOperation.Repository;

namespace Using_GenericRepository_CrudOperation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenericService genericService;

        public EmployeeController(IGenericService genericService)
        {
            this.genericService = genericService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<tblEmployee> employees = await genericService.GetAllAsync<tblEmployee>();
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
                tblEmployee employee = await genericService.GetByIdAsync<tblEmployee>(id.Value);
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
                        await genericService.AddAsync(model);
                        TempData["success"] = "Employee added successfully.";
                    }
                    else
                    {
                        await genericService.UpdateAsync(model);
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
                tblEmployee employee = await genericService.GetByIdAsync<tblEmployee>(id);
                if (employee == null)
                {
                    return NotFound();
                }
                await genericService.DeleteAsync<tblEmployee>(id);
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
