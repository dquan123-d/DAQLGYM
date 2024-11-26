using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblMemberService
{
    public int ServiceRegistrationId { get; set; }

    public int? MemberId { get; set; }

    public int? ServiceId { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public string? StatusMemberServices { get; set; }

    public virtual TblMember? Member { get; set; }

    public virtual TblService? Service { get; set; }
}
