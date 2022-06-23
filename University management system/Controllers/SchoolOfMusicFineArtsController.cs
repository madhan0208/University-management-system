using Microsoft.AspNetCore.Mvc;
using University_management_system.Data;
using University_management_system.Models;

namespace University_management_system.Controllers
{
    public class SchoolOfMusicFineArtsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SchoolOfMusicFineArtsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SchoolofMusicFineArts> objschoolOfmusicfinearts = _db.schoolofMusicFineArts;
            return View(objschoolOfmusicfinearts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SchoolofMusicFineArts obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolofMusicFineArts.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index", "SchoolOfMusicFineArts");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolofMusicFineArtsFind = _db.schoolofMusicFineArts.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolofMusicFineArtsFind == null)
            {
                return NotFound();
            }
            return View(SchoolofMusicFineArtsFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolofMusicFineArts obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolofMusicFineArts.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index", "SchoolOfMusicFineArts");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfMusicFineArtsFind = _db.schoolofMusicFineArts.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfMusicFineArtsFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfMusicFineArtsFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.schoolofMusicFineArts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.schoolofMusicFineArts.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index", "SchoolOfMusicFineArts");

        }
    }
}
