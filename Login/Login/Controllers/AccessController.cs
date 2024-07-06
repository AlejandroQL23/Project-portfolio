using Microsoft.AspNetCore.Mvc;
using Login.Data;
using Login.Models;
using Microsoft.EntityFrameworkCore;
using Login.ViewModels;

namespace Login.Controllers
{
    public class AccessController : Controller
    {
        private readonly appDBContext _context;
        public AccessController(appDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(UserVM model)
        {
            if(model.Password != model.rePassword)
            {
                ViewData["Mensaje"] = "Las contrasennas no coinciden";
                return View();
            }
            User user = new User()
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            if (user.Id != 0) return RedirectToAction("Login", "Acceso");
            ViewData["Mensaje"] = "NO se creo usuario";
            return View();
        }
    }
}
