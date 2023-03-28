using Test_Invoice_Yhra.Models.DB;
using Test_Invoice_Yhra.Services.Customers;
using Test_Invoice_Yhra.Services.Invoices;
using Test_Invoice_Yhra.Services.CustomersTypes;
using Test_Invoice_Yhra.Services.InvoiceDetails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(TestInvoiceContext), typeof(TestInvoiceContext));
builder.Services.AddScoped(typeof(IInvoiceServices), typeof(InvoiceServices));
builder.Services.AddScoped(typeof(ICustomersServices), typeof(CustomersServices));
builder.Services.AddScoped(typeof(ICustomersTypesServices), typeof(CustomersTypesServices));
builder.Services.AddScoped(typeof(IInvoiceDetailServices), typeof(InvoiceDetailServices));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customers}/{action=Index}/{id?}");

app.Run();
