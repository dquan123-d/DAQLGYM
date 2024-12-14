using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblMemberPackage
{
    public int MemberPackageId { get; set; }

    public string? MemberName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public bool? IsActive { get; set; }

    public int? PackageId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int ClassId { get; set; }

    public virtual TblClass Class { get; set; } = null!;

    public virtual TblPackage? Package { get; set; }

    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();
}
