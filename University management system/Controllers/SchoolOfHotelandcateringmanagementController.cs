using Microsoft.AspNetCore.Mvc;
using University_management_system.Data;
using University_management_system.Models;

namespace University_management_system.Controllers
{
    public class SchoolOfHotelandcateringmanagementController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SchoolOfHotelandcateringmanagementController(ApplicationDbContext db)
        {
            _db = db;
        }

         public IActionResult Index()
        {
            IEnumerable<SchoolOfHotelandCateringManagement> objHotelandcateringmanagements = _db.schoolOfHotelandCateringManagements;

            return View(objHotelandcateringmanagements);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SchoolOfHotelandCateringManagement obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfHotelandCateringManagements.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index", "SchoolOfHotelandCateringManagement");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfHotelandCateringManagementFind = _db.schoolOfHotelandCateringManagements.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfHotelandCateringManagementFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfHotelandCateringManagementFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolOfHotelandCateringManagement obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfHotelandCateringManagements.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index", "SchoolOfHotelandCateringManagement");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfHotelandCateringManagementFind = _db.schoolOfHotelandCateringManagements.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfHotelandCateringManagementFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfHotelandCateringManagementFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.schoolOfPharmacies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.schoolOfPharmacies.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index", "SchoolOfHotelandCateringManagement");

        }
    }
}
