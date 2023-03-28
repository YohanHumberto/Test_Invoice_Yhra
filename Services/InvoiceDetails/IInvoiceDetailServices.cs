using Test_Invoice_Yhra.Models.DB;

namespace Test_Invoice_Yhra.Services.InvoiceDetails
{
    public interface IInvoiceDetailServices
    {
        public InvoiceDetail GetbyId(int id);

        public List<InvoiceDetail> GetAll();

        public bool Add(InvoiceDetail invoiceDetail);

        public bool Update(InvoiceDetail invoiceDetail);

        public bool Delete(int id);
    }
}
