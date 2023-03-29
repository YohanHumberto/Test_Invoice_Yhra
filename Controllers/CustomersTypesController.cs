using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test_Invoice_Yhra.Models.DB;
using Test_Invoice_Yhra.Services.Customers;
using Test_Invoice_Yhra.Services.CustomersTypes;

namespace Test_Invoice_Yhra.Controllers
{
    public class CustomersTypesController : Controller
    {

        private readonly ICustomersTypesServices customersTypesServices;

        public CustomersTypesController(ICustomersTypesServices customersTypesServices)
        {
            this.customersTypesServices = customersTypesServices;
        }

        public IActionResult Index()
        {
            var listCustomersTypes = customersTypesServices.GetAll();
            return View(listCustomersTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] CustomerType customerType)
        {
            customersTypesServices.Add(customerType);
            return Redirect("Index");
        }

        public ActionResult Edit(int id)
        {
            var customerType = customersTypesServices.GetbyId(id);
            return View(customerType);
        }

        [HttpPost]
        public ActionResult Edit(int id, [FromForm] CustomerType customerType)
        {
            try
            {
                customerType.Id = id;
                customersTypesServices.Update(customerType);
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
                customersTypesServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }

        }

    }
}
