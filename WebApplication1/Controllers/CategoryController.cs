using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {

        //creating private readonly database object
        private readonly ApplicationDbContext _db;

        //creating a constructor to get data from the database
        public CategoryController(ApplicationDbContext db) {
            _db = db;
        }

        //converting database items to list


        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList=_db.Category;

            return View(objCategoryList);
        }

        //Creating a new category
        //action result for create view
        //GET
        public IActionResult Create()
        {

            return View();
        }

        //sending post request to database on form submit
        //POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid) {
                _db.Category.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The category created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
            
        }

        //Editing catiegory
        //Get

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            var categoryFromDb=_db.Category.Find(id);
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The category updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        //Deleting category
        //get

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            var categoryFromDb = _db.Category.Find(id);
            return View(categoryFromDb);
        }

        //post
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(Category obj)
        {
            
                _db.Category.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "The category Deleted successfully";
            return RedirectToAction("Index");
           

        }



    }
}
