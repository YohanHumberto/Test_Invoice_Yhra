using Test_Invoice_Yhra.Models.DB;

namespace Test_Invoice_Yhra.Services.CustomersTypes
{
    public class CustomersTypesServices : ICustomersTypesServices
    {

        private TestInvoiceContext testInvoiceContext;

        public CustomersTypesServices(TestInvoiceContext testInvoiceContext)
        {
            this.testInvoiceContext = testInvoiceContext;
        }

        public CustomerType GetbyId(int id)
        {
            return testInvoiceContext.CustomerTypes.Where(A => A.Id == id).FirstOrDefault();
        }

        public List<CustomerType> GetAll()
        {
            return testInvoiceContext.CustomerTypes.ToList();
        }

        public bool Add(CustomerType customerType)
        {
            testInvoiceContext.CustomerTypes.Add(customerType);
            testInvoiceContext.SaveChanges();
            return false;
        }

        public bool Update(CustomerType customerType)
        {
            var item = testInvoiceContext.CustomerTypes.Where(A => A.Id == customerType.Id).FirstOrDefault();
            if (item != null)
            {
                item.Description= customerType.Description;
                testInvoiceContext.CustomerTypes.Update(item);
                testInvoiceContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var customerType = testInvoiceContext.CustomerTypes.Where(A => A.Id == id).SingleOrDefault();
            if (customerType != null)
            {
                testInvoiceContext.CustomerTypes.Remove(customerType);
                testInvoiceContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}