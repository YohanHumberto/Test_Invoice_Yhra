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

        public InvoiceDetail? GetbyId(int id)
        {
            return testInvoiceContext.InvoiceDetails.Where(A => A.Id == id).FirstOrDefault();
        }

        public List<InvoiceDetail> GetAll()
        {
            return testInvoiceContext.InvoiceDetails.ToList();
        }

        public bool Add(InvoiceDetail invoiceDetail, IInvoiceDetailServices.UpdateInvoiceHeader updateInvoiceHeader)
        {
            invoiceDetail.SubTotal = invoiceDetail.Qty * invoiceDetail.Price;
            invoiceDetail.TotalItbis = invoiceDetail.SubTotal * new decimal(0.18);
            invoiceDetail.Total = invoiceDetail.SubTotal * invoiceDetail.TotalItbis;

            var item = testInvoiceContext.InvoiceDetails.Add(invoiceDetail);
            testInvoiceContext.SaveChanges();

            updateInvoiceHeader(item.Entity.InvoiceId);
            return false;
        }

        public bool Update(InvoiceDetail invoiceDetail, IInvoiceDetailServices.UpdateInvoiceHeader updateInvoiceHeader)
        {
            var item = testInvoiceContext.InvoiceDetails.Where(A => A.Id == invoiceDetail.Id).FirstOrDefault();
            if (item != null)
            {
                item.InvoiceId = invoiceDetail.InvoiceId;
                item.Qty = invoiceDetail.Qty;
                item.Price = invoiceDetail.Price;

                item.SubTotal = item.Price * item.Qty;
                item.TotalItbis = item.SubTotal * new decimal(0.18);
                item.Total = item.TotalItbis + item.SubTotal;

                testInvoiceContext.InvoiceDetails.Update(item);
                testInvoiceContext.SaveChanges();

                updateInvoiceHeader(item.InvoiceId);
                return true;
            }
            return false;
        }

        public bool Delete(int id, IInvoiceDetailServices.UpdateInvoiceHeader updateInvoiceHeader)
        {
            var invoiceDetail = testInvoiceContext.InvoiceDetails.Where(A => A.Id == id).FirstOrDefault();
            if (invoiceDetail != null)
            {
                testInvoiceContext.InvoiceDetails.Remove(invoiceDetail);
                testInvoiceContext.SaveChanges();

                updateInvoiceHeader(invoiceDetail.InvoiceId);
                return true;
            }
            return false;
        }

    }
}
