using Microsoft.AspNetCore.Mvc;
using University_management_system.Data;
using University_management_system.Models;

namespace University_management_system.Controllers
{
    public class SchoolOfPharmacyController : Controller
    {

        private readonly ApplicationDbContext _db;

        public SchoolOfPharmacyController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SchoolofPharmacy> objschoolofPharmacies = _db.schoolOfPharmacies;
            return View(objschoolofPharmacies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SchoolofPharmacy obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfPharmacies.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index","SchoolOfPharmacy");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolofPharmacyFind = _db.schoolOfPharmacies.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolofPharmacyFind == null)
            {
                return NotFound();
            }
            return View(SchoolofPharmacyFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolofPharmacy obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfPharmacies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index", "SchoolOfPharmacy");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolofPharmacyFind = _db.schoolOfPharmacies.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolofPharmacyFind == null)
            {
                return NotFound();
            }
            return View(SchoolofPharmacyFind);
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
            return RedirectToAction("Index","SchoolOfPharmacy");

        }
    }
}
