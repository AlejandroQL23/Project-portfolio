using Microsoft.AspNetCore.Mvc;
using appCRUD.Data;
using appCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace appCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public EmployeeController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            List<employee> list = await _appDBContext.Employees.ToListAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(employee employee)
        {
            await _appDBContext.Employees.AddAsync(employee);
            await _appDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int idEmployee)
        {
            employee employee = await _appDBContext.Employees.FirstAsync(e => e.Id == idEmployee);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(employee employee)
        {
            _appDBContext.Employees.Update(employee);   
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
