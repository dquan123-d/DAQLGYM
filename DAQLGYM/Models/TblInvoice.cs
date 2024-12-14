using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblInvoice
{
    public int InvoiceId { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public int? TotalAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? StatusInvoices { get; set; }

    public string? Notes { get; set; }

    public int? MemberPackageId { get; set; }

    public virtual TblMemberPackage? MemberPackage { get; set; }
}
