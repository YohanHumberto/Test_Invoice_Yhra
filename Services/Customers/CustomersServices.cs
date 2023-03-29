using Test_Invoice_Yhra.Models.DB;

namespace Test_Invoice_Yhra.Services.Customers
{
    public class CustomersServices : ICustomersServices
    {
        private TestInvoiceContext testInvoiceContext;

        public CustomersServices(TestInvoiceContext testInvoiceContext)
        {
            this.testInvoiceContext = testInvoiceContext;
        }

        public Customer GetbyId(int id)
        {
            return testInvoiceContext.Customers.Where(A => A.Id == id).FirstOrDefault();
        }

        public List<Customer> GetAll()
        {
            return testInvoiceContext.Customers.ToList();
        }

        public bool Add(Customer customer)
        {
            testInvoiceContext.Customers.Add(customer);
            testInvoiceContext.SaveChanges();
            return false;
        }

        public bool Update(Customer customer)
        {
            var item = testInvoiceContext.Customers.Where(A => A.Id == customer.Id).FirstOrDefault();

            if (item != null)
            {
                item.CustName = customer.CustName;
                item.Adress = customer.Adress;
                item.Status = customer.Status;
                item.CustomerType = customer.CustomerType;

                testInvoiceContext.Customers.Update(item);
                testInvoiceContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var customer = testInvoiceContext.Customers.Where(A => A.Id == id).FirstOrDefault();
            if (customer != null)
            {
                testInvoiceContext.Customers.Remove(customer);
                testInvoiceContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
