using Test_Invoice_Yhra.Models.DB;

namespace Test_Invoice_Yhra.Services.InvoiceDetails
{
    public class InvoiceDetailServices : IInvoiceDetailServices
    {
        private TestInvoiceContext testInvoiceContext;

        public InvoiceDetailServices(TestInvoiceContext testInvoiceContext)
        {
            this.testInvoiceContext = testInvoiceContext;
        }

        public InvoiceDetail GetbyId(int id)
        {
            return testInvoiceContext.InvoiceDetails.Where(A => A.Id == id).FirstOrDefault();
        }

        public List<InvoiceDetail> GetAll()
        {
            return testInvoiceContext.InvoiceDetails.ToList();
        }

        public bool Add(InvoiceDetail invoiceDetail)
        {
            testInvoiceContext.InvoiceDetails.Add(invoiceDetail);
            testInvoiceContext.SaveChanges();
            return false;
        }

        public bool Update(InvoiceDetail invoiceDetail)
        {
            var item = testInvoiceContext.InvoiceDetails.Where(A => A.Id == invoiceDetail.Id).FirstOrDefault();
            if (item != null)
            {
                item.Price = invoiceDetail.Price;
                item.Qty = invoiceDetail.Qty;
                item.CustomerId = invoiceDetail.CustomerId;
                item.SubTotal = invoiceDetail.SubTotal;
                item.TotalItbis= invoiceDetail.TotalItbis;
                item.Total = invoiceDetail.Total;   

                testInvoiceContext.InvoiceDetails.Update(item);
                testInvoiceContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var invoiceDetail = testInvoiceContext.InvoiceDetails.Where(A => A.Id == id).FirstOrDefault();
            if (invoiceDetail != null)
            {
                testInvoiceContext.InvoiceDetails.Remove(invoiceDetail);
                testInvoiceContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
