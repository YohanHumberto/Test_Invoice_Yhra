﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test_Invoice_Yhra.Models.DB;
using Test_Invoice_Yhra.Services.Customers;
using Test_Invoice_Yhra.Services.Invoices;

namespace Test_Invoice_Yhra.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceServices invoiceServices;
        private readonly ICustomersServices customersServices;

        public InvoiceController(IInvoiceServices invoiceServices, ICustomersServices customersServices)
        {
            this.invoiceServices = invoiceServices;
            this.customersServices = customersServices;
        }

        public IActionResult Index()
        {
            var listInvoices = invoiceServices.GetAll();
            return View(listInvoices);
        }

        public IActionResult Create()
        {
            ViewBag.ListCustomers = new SelectList(customersServices.GetAll(), "Id", "CustName");
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Invoice invoice)
        {
            invoiceServices.Add(invoice);
            return Redirect("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListCustomers = new SelectList(customersServices.GetAll(), "Id", "CustName");
            var invoice = invoiceServices.GetbyId(id);
            return View(invoice);
        }

        [HttpPost]
        public ActionResult Edit(int id, [FromForm] Invoice invoice)
        {
            try
            {
                invoice.Id = id;
                invoiceServices.Update(invoice);
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
                invoiceServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }

        }

    }
}
