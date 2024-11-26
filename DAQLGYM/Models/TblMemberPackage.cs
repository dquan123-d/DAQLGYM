using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblMemberPackage
{
    public int MemberPackageId { get; set; }

    public int? MemberId { get; set; }

    public int? PackageId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public int? StatusMemberPackages { get; set; }

    public virtual TblMember? Member { get; set; }

    public virtual TblPackage? Package { get; set; }
}
