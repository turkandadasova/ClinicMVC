using ClinicMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace ClinicMVC.Areas.Admin.Controllers
{
    public class DoctorController(ClinicDbContext _context) : Controller
    {
        [Area("Admin")]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
