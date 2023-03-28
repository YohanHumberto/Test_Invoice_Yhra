using Test_Invoice_Yhra.Models.DB;

namespace Test_Invoice_Yhra.Services.CustomersTypes
{
    public interface ICustomersTypesServices
    {
        public CustomerType GetbyId(int id);

        public List<CustomerType> GetAll();

        public bool Add(CustomerType customerType);

        public bool Update(CustomerType customerType);

        public bool Delete(int id);
    }
}
