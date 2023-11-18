using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategorieController : Controller
    {
        private readonly AppkicationContext context;

        // GET: CategorieController
        public CategorieController(AppkicationContext context)
        {
            this.context = context;
        }
        // GET: CategorieController
        public ActionResult Index()
        {
            List<Categorie> categories = context.Categories.ToList();
            return View(categories);
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategorieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie categorie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (context.Categories
                        .Where(x => x.CatName == categorie.CatName)
                        .Count() > 0)
                    {
                        ViewBag.Message = "Categorie existe";
                        return View(categorie);
                    }
                    Categorie c = new Categorie();
                    c.CatID = categorie.CatID;
                    c.CatName = categorie.CatName;
                    context.Categories.Add(c);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(categorie);
                }

            }
            catch
            {
                return View(categorie);
            }
        }

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            Categorie categorie =
               context.Categories.Find(id);
            return View(categorie);
        }

        // POST: CategorieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Categorie categorie)
        {
            try
            {
                context.Categories.Remove(categorie);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
