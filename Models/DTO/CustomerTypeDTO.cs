using System;
using System.Collections.Generic;

namespace Test_Invoice_Yhra.Models.DB.DTO;

public partial class CustomerTypeDTO
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;
}
