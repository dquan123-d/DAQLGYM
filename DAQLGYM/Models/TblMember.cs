using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblMember
{
    public int MemberId { get; set; }

    public string? FullName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateOnly? JoinDate { get; set; }

    public int? Status { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? ProfileImage { get; set; }

    public string? Role { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<TblComment> TblComments { get; set; } = new List<TblComment>();

    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();

    public virtual ICollection<TblMemberPackage> TblMemberPackages { get; set; } = new List<TblMemberPackage>();

    public virtual ICollection<TblMemberService> TblMemberServices { get; set; } = new List<TblMemberService>();

    public virtual ICollection<TblSchedule> TblSchedules { get; set; } = new List<TblSchedule>();
}
