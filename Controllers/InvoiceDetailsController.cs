using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test_Invoice_Yhra.Models.DB;
using Test_Invoice_Yhra.Services.InvoiceDetails;
using Test_Invoice_Yhra.Services.Invoices;

namespace Test_Invoice_Yhra.Controllers
{
    public class InvoiceDetailsController : Controller
    {

        private readonly IInvoiceDetailServices invoiceDetailServices;
        private readonly IInvoiceServices invoiceServices;

        public InvoiceDetailsController(IInvoiceDetailServices invoiceDetailServices, IInvoiceServices invoiceServices)
        {
            this.invoiceDetailServices = invoiceDetailServices;
            this.invoiceServices = invoiceServices;
        }

        public IActionResult Index()
        {
            var listInvoicesDetails = invoiceDetailServices.GetAll();
            return View(listInvoicesDetails);
        }

        public IActionResult Create()
        {
            ViewBag.ListInvoice = new SelectList(invoiceServices.GetAll(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] InvoiceDetail invoiceDetail)
        {
            invoiceDetailServices.Add(invoiceDetail, invoiceServices.UpdateBalance);
            return Redirect("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListInvoice = new SelectList(invoiceServices.GetAll(), "Id", "Id");
            var invoice = invoiceDetailServices.GetbyId(id);
            return View(invoice);
        }

        [HttpPost]
        public ActionResult Edit(int id, [FromForm] InvoiceDetail invoiceDetail)
        {
            try
            {
                invoiceDetail.Id = id;
                invoiceDetailServices.Update(invoiceDetail, invoiceServices.UpdateBalance);
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
                invoiceDetailServices.Delete(id, invoiceServices.UpdateBalance);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }

        }

    }
}
