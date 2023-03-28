using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_Invoice_Yhra.Controllers
{
    public class CustomersTypes : Controller
    {
        // GET: CustomersTypes
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomersTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CustomersTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersTypes/Edit/5
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

        // GET: CustomersTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersTypes/Delete/5
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
