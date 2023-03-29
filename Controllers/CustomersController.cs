using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test_Invoice_Yhra.Models.DB;
using Test_Invoice_Yhra.Services.Customers;
using Test_Invoice_Yhra.Services.CustomersTypes;

namespace Test_Invoice_Yhra.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersServices customersServices;
        private readonly ICustomersTypesServices customersTypesServices;

        public CustomersController(ICustomersServices customersServices, ICustomersTypesServices customersTypesServices)
        {
            this.customersServices = customersServices;
            this.customersTypesServices = customersTypesServices;
        }

        public IActionResult Index()
        {
            var listCustomers = customersServices.GetAll();
            return View(listCustomers);
        }

        public IActionResult Create()
        {
            ViewBag.ListCustomerType = new SelectList(customersTypesServices.GetAll(), "Id", "Description");
            ViewBag.ListStatus = new SelectList(new Dictionary<int, string>() { { 1, "Activo" }, { 0, "Inactivo" } }.Select(a => new { value = a.Key, text = a.Value }), "value", "text");
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Customer customer)
        {
            customersServices.Add(customer);
            return Redirect("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListCustomerType = new SelectList(customersTypesServices.GetAll(), "Id", "Description");
            ViewBag.ListStatus = new SelectList(new Dictionary<bool, string>() { { true, "Activo" }, { false, "Inactivo" } }.Select(a => new { value = a.Key, text = a.Value }), "value", "text");
            var customer = customersServices.GetbyId(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(int id, [FromForm] Customer customer)
        {
            try
            {
                customer.Id = id;
                customersServices.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                customersServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }

        }

    }
}