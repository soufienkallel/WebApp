using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProducerController : Controller
    {
        private readonly AppkicationContext context;

        // GET: ProducerController
        public ProducerController(AppkicationContext context)
        {
            this.context = context;
        }
        
        public ActionResult Index()
        {
            List<Producer> producers = context.Producers.ToList();
            return View(producers);
        }

        // GET: ProducerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProducerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer producer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (context.Producers
                        .Where(x => x.ProdName == producer.ProdName)
                        .Count() > 0)
                    {
                        ViewBag.Message = "Producer existe";
                        return View(producer);
                    }
                    Producer p = new Producer();
                    p.ProdID = producer.ProdID;
                    p.ProdName = producer.ProdName;
                    context.Producers.Add(p);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(producer);
                }

            }
            catch
            {
                return View(producer);
            }
        }

        // POST: ProducerController/Edit/5
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

        // GET: ProducerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProducerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
