using Microsoft.AspNetCore.Mvc;
using University_management_system.Data;
using University_management_system.Models;

namespace University_management_system.Controllers
{
    public class SchoolOfManagementandCommerceController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SchoolOfManagementandCommerceController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SchoolOfManagementandCommerce> objschoolofmanagementandcommerce = _db.schoolOfManagementandCommerces;
            return View(objschoolofmanagementandcommerce);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SchoolOfManagementandCommerce obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfManagementandCommerces.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index", "SchoolOfManagementandCommerce");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfManagementandCommerceFind = _db.schoolOfManagementandCommerces.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfManagementandCommerceFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfManagementandCommerceFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolOfManagementandCommerce obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("email", "Email id should not begin or end with Name");
            }
            if (ModelState.IsValid)
            {
                _db.schoolOfManagementandCommerces.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index", "SchoolOfManagementandCommerce");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SchoolOfManagementandCommerceFind = _db.schoolOfManagementandCommerces.Find(id);
            //var ProfileFirst = _db.Profiles.FirstOrDefault(u => u.Id == id);
            //var ProfileSingel = _db.Profiles.SingleOrDefault(u => u.Id == id);
            if (SchoolOfManagementandCommerceFind == null)
            {
                return NotFound();
            }
            return View(SchoolOfManagementandCommerceFind);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.schoolOfManagementandCommerces.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.schoolOfManagementandCommerces.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index", "SchoolOfManagementandCommerce");

        }
    }
}
