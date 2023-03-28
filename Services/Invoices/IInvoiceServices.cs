using Test_Invoice_Yhra.Models.DB;

namespace Test_Invoice_Yhra.Services.Invoices
{
    public interface IInvoiceServices
    {
        public Invoice GetbyId(int id);

        public List<Invoice> GetAll();

        public bool Add(Invoice invoice);

        public bool Update(Invoice invoice);

        public bool Delete(int id);
    }
}
