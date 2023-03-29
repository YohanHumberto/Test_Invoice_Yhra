using Microsoft.AspNetCore.Mvc;

namespace Test_Invoice_Yhra.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
