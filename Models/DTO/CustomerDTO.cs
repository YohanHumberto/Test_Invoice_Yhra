using System;
using System.Collections.Generic;

namespace Test_Invoice_Yhra.Models.DB.DTO;

public partial class CustomerDTO
{
    public int Id { get; set; }

    public string CustName { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public bool? Status { get; set; }

    public int CustomerTypeId { get; set; }
}
