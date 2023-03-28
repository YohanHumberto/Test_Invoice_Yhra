using System;
using System.Collections.Generic;

namespace Test_Invoice_Yhra.Models.DB.DTO;

public partial class InvoiceDetailDTO
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public decimal TotalItbis { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Total { get; set; }

}
