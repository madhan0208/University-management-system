using Microsoft.AspNetCore.Mvc;
using University_management_system.Data;
using University_management_system.Models;

namespace University_management_system.Controllers
{
    public class SchoolOfLawController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SchoolOfLawController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SchoolOfLaw> objschoolOfLaw = _db.schoolOfLaws;
            return View(objschoolOfLaw);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SchoolOfLaw obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfLaws.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index", "SchoolOfLaw");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfLawFind = _db.schoolOfLaws.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfLawFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfLawFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolOfLaw obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfLaws.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index", "SchoolOfLaw");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfLawFind = _db.schoolOfLaws.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfLawFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfLawFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.schoolOfLaws.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.schoolOfLaws.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index", "SchoolOfLaw");

        }
    }
}
