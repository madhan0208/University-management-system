using Microsoft.AspNetCore.Mvc;
using University_management_system.Data;
using University_management_system.Models;

namespace University_management_system.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Profile> objprofilelist=_db.Profiles;
            return View(objprofilelist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Profile obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            { 
            _db.Profiles.Add(obj);
            _db.SaveChanges();
                TempData["success"] = "Created Successfully";
            return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id ==0)
            {
                return NotFound();
            }
            var ProfileFind=_db.Profiles.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (ProfileFind == null)
            {
                return NotFound();
            }
            return View(ProfileFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Profile obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.Profiles.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ProfileFind = _db.Profiles.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (ProfileFind == null)
            {
                return NotFound();
            }
            return View(ProfileFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int  ? id )
        {
            var obj = _db.Profiles.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Profiles.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        
        }

    }
}
