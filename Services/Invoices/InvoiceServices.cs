using Microsoft.EntityFrameworkCore;
using Test_Invoice_Yhra.Models.DB;

namespace Test_Invoice_Yhra.Services.Invoices
{
    public class InvoiceServices : IInvoiceServices
    {

        private TestInvoiceContext testInvoiceContext;

        public InvoiceServices(TestInvoiceContext testInvoiceContext)
        {
            this.testInvoiceContext = testInvoiceContext;
        }

        public Invoice? GetbyId(int id)
        {
            return testInvoiceContext.Invoices.Where(A => A.Id == id).FirstOrDefault();
        }

        public List<Invoice> GetAll()
        {
            return testInvoiceContext.Invoices.Include(t=>t.Customer).ToList();
        }

        public bool Add(Invoice invoice)
        {
            invoice.TotalItbis = invoice.SubTotal * new decimal(0.18);
            invoice.Total = invoice.SubTotal + invoice.TotalItbis;
            testInvoiceContext.Invoices.Add(invoice);
            testInvoiceContext.SaveChanges();
            return false;
        }

        public bool Update(Invoice invoice)
        {
            var item = testInvoiceContext.Invoices.Where(A => A.Id == invoice.Id).FirstOrDefault();
            if (item != null)
            {
                item.CustomerId = invoice.CustomerId;
                item.SubTotal = invoice.SubTotal;

                item.TotalItbis = item.SubTotal * new decimal(0.18);
                item.Total = item.SubTotal + item.TotalItbis;

                testInvoiceContext.Invoices.Update(item);
                testInvoiceContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var invoice = testInvoiceContext.Invoices.Where(A => A.Id == id).FirstOrDefault();
            if (invoice != null)
            {
                testInvoiceContext.Invoices.Remove(invoice);
                testInvoiceContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateBalance(int id)
        {
            Invoice? invoice = testInvoiceContext.Invoices.Include(a=>a.InvoiceDetails).Where(A => A.Id == id).FirstOrDefault();
            if (invoice != null)
            {
                invoice.SubTotal = 0;
                invoice.InvoiceDetails.ToList().ForEach(a =>
                {
                    invoice.SubTotal += a.SubTotal;
                });
                this.Update(invoice);
                return true;
            }
            return false;
        }

    }
}
