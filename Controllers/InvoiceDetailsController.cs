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

        public IActionResult Index(int? invoiceId)
        {
            ViewBag.InvoiceId = invoiceId;
            var listInvoicesDetails = invoiceDetailServices.GetAll().Where(a => a.InvoiceId == invoiceId || invoiceId < 0).ToList();
            return View(listInvoicesDetails);
        }

        public IActionResult Create(int? invoiceId)
        {
            ViewBag.InvoiceId = invoiceId;
            ViewBag.ListInvoice = new SelectList(invoiceServices.GetAll().Where(a => a.Id == invoiceId).ToList(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] InvoiceDetail invoiceDetail)
        {
            invoiceDetailServices.Add(invoiceDetail, invoiceServices.UpdateBalance);
            return RedirectToAction(nameof(Index), new { invoiceId = invoiceDetail.InvoiceId });
        }

        public ActionResult Edit(int id)
        {
            ViewBag.InvoiceId = invoiceDetailServices.GetbyId(id)?.InvoiceId;
            ViewBag.ListInvoice = new SelectList(invoiceServices.GetAll().Where(a => a.Id == ViewBag.InvoiceId).ToList(), "Id", "Id");
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
                return RedirectToAction(nameof(Edit), new { invoiceId = invoiceDetail.InvoiceId });
            }
        }

        public IActionResult Delete(int id)
        {
            var invoiceId = invoiceDetailServices.GetbyId(id)?.InvoiceId;
            try
            {
                invoiceDetailServices.Delete(id, invoiceServices.UpdateBalance);
                return RedirectToAction(nameof(Index), new { invoiceId });
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index), new { invoiceId });
            }

        }

    }
}
