using Microsoft.AspNetCore.Mvc;
using University_management_system.Data;
using University_management_system.Models;

namespace University_management_system.Controllers
{
    public class SchoolOfPhysiotherapyController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SchoolOfPhysiotherapyController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SchoolOfPhysiotherapy> objschoolOfPhysiotherapies = _db.schoolOfPhysiotherapies;
            return View(objschoolOfPhysiotherapies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SchoolOfPhysiotherapy obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfPhysiotherapies.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index", "SchoolOfPhysiotherapy");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfPhysiotherapyFind = _db.schoolOfPhysiotherapies.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfPhysiotherapyFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfPhysiotherapyFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolOfPhysiotherapy obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfPhysiotherapies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index", "SchoolOfPhysiotherapy");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfPhysiotherapyFind = _db.schoolOfPhysiotherapies.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfPhysiotherapyFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfPhysiotherapyFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.schoolOfPhysiotherapies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.schoolOfPhysiotherapies.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index", "SchoolOfPhysiotherapy");

        }
    }
}
