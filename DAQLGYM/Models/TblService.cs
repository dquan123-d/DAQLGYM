using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblService
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public decimal? Price { get; set; }

    public string? Describe { get; set; }

    public string? ImageServices { get; set; }

    public virtual ICollection<TblComment> TblComments { get; set; } = new List<TblComment>();

    public virtual ICollection<TblMemberService> TblMemberServices { get; set; } = new List<TblMemberService>();
}
