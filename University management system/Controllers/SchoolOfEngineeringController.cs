using Microsoft.AspNetCore.Mvc;
using University_management_system.Data;
using University_management_system.Models;

namespace University_management_system.Controllers
{
    public class SchoolOfEngineeringController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SchoolOfEngineeringController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SchoolOfEngineering> objschoolOfEngineerings = _db.schoolOfEngineerings;
            return View(objschoolOfEngineerings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SchoolOfEngineering obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfEngineerings.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index", "SchoolOfEngineering");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfEngineeringFind = _db.schoolOfEngineerings.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfEngineeringFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfEngineeringFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolOfEngineering obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfEngineerings.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index", "SchoolOfEngineering");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfEngineeringFind = _db.schoolOfEngineerings.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfEngineeringFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfEngineeringFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.schoolOfEngineerings.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.schoolOfEngineerings.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index", "SchoolOfEngineering");

        }
    }
}
