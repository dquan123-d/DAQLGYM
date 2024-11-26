using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblInvoiceDetail
{
    public int DetailId { get; set; }

    public int? InvoiceId { get; set; }

    public string? ItemName { get; set; }

    public int? Quantity { get; set; }

    public int? TotalAmount { get; set; }

    public virtual TblInvoice? Invoice { get; set; }
}
