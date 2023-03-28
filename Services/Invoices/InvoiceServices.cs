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

        public Invoice GetbyId(int id)
        {
            return testInvoiceContext.Invoices.Where(A => A.Id == id).FirstOrDefault();
        }

        public List<Invoice> GetAll()
        {
            return testInvoiceContext.Invoices.ToList();
        }

        public bool Add(Invoice invoice)
        {
            testInvoiceContext.Invoices.Add(invoice);
            testInvoiceContext.SaveChanges();
            return false;
        }

        public bool Update(Invoice invoice)
        {
            var item = testInvoiceContext.Customers.Where(A => A.Id == invoice.Id).FirstOrDefault();
            if (item != null)
            {
                testInvoiceContext.Customers.Update(item);
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

    }
}
