using ClinicMVC.DataAccess;
using ClinicMVC.Models;
using ClinicMVC.ViewModels.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC.Areas.Admin.Controllers
{
    public class DoctorController(ClinicDbContext _context) : Controller
    {
        [Area("Admin")]


        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorCreateVm vm)
        {
            //if (vm.CoverFile != null)
            //{
            //    if (!vm.IsValidType("image"))
            //        ModelState.AddModelError("File", "File must be image!");
            //    if (!vm.File.IsValidSize(5 * 1024))
            //        ModelState.AddModelError("File", "File length must be less than 2mg");
            //}

            if (!ModelState.IsValid) return View();

            //string newFileName = await vm.File.UploadAsync(_env.WebRootPath, "imgs", "sliders");


            Doctor doctor = new Doctor
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Position = vm.Position,
                Department = vm.Department,
            };

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {

            if (!id.HasValue) return BadRequest();

            var data = await _context.Doctors.FindAsync(id);

            if (data is null) return NotFound();

            DoctorUpdateVm vm = new();

            vm.Name = data.Name;
            vm.Surname = data.Surname;
            vm.Position = data.Position;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, DoctorUpdateVm vm)
        {
            if (!id.HasValue) return BadRequest();

            var data = await _context.Doctors.FindAsync(id);

            if (data is null) return NotFound();


            //if (vm.File != null)
            //{
            //    if (!vm.File.IsValidType("image"))
            //        ModelState.AddModelError("File", "File must be image!");
            //    if (!vm.File.IsValidSize(5 * 1024))
            //        ModelState.AddModelError("File", "File length must be less than 2mg");

            //    string oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgs", "sliders", data.ImageUrl);

            //    if (System.IO.File.Exists(oldFilePath))
            //    {
            //        System.IO.File.Delete(oldFilePath);
            //    }

            //    string newFileName = await vm.File.UploadAsync(_env.WebRootPath, "imgs", "sliders");
            //    data.ImageUrl = newFileName;
            //}

            if (!ModelState.IsValid) return View(vm);

            data.Name = vm.Name;
            data.Surname = vm.Surname;
            data.Position = vm.Position;
            data.Department = vm.Department;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var data = await _context.Doctors.FindAsync(id);

            if (data is null) return NotFound();

            //string oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgs", "sliders", data.ImageUrl);

            //if (System.IO.File.Exists(oldFilePath))
            //{
            //    System.IO.File.Delete(oldFilePath);
            //}

            _context.Doctors.Remove(data);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
