using Test_Invoice_Yhra.Models.DB;

namespace Test_Invoice_Yhra.Services.Customers
{
    public interface ICustomersServices
    {
        public Customer GetbyId(int id);

        public List<Customer> GetAll();

        public bool Add(Customer customer);

        public bool Update(Customer customer);

        public bool Delete(int id);
    }
}
