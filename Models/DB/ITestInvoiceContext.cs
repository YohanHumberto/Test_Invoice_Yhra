using Microsoft.EntityFrameworkCore;

namespace Test_Invoice_Yhra.Models.DB
{
    public interface ITestInvoiceContext
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<CustomerType> CustomerTypes { get; set; }

        DbSet<Invoice> Invoices { get; set; }

        DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        void OnConfiguring(DbContextOptionsBuilder optionsBuilder);

        void OnModelCreating(ModelBuilder modelBuilder);

        void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
