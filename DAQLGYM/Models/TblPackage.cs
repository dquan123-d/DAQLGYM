using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblPackage
{
    public int PackageId { get; set; }

    public string? PackageName { get; set; }

    public int? Duration { get; set; }

    public int? Price { get; set; }

    public string? Describe { get; set; }

    public string? ImagePackages { get; set; }

    public virtual ICollection<TblMemberPackage> TblMemberPackages { get; set; } = new List<TblMemberPackage>();
}
