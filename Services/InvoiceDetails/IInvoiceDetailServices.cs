using Test_Invoice_Yhra.Models.DB;

namespace Test_Invoice_Yhra.Services.InvoiceDetails
{
    public interface IInvoiceDetailServices
    {
        public delegate bool UpdateInvoiceHeader(int invoiceId);

        public InvoiceDetail? GetbyId(int id);

        public List<InvoiceDetail> GetAll();

        public bool Add(InvoiceDetail invoiceDetail, UpdateInvoiceHeader updateInvoiceHeader);

        public bool Update(InvoiceDetail invoiceDetail, UpdateInvoiceHeader updateInvoiceHeader);

        public bool Delete(int id, UpdateInvoiceHeader updateInvoiceHeader);
    }
}
