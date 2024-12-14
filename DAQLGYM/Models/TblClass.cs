using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblClass
{
    public int ClassId { get; set; }

    public string? NameClass { get; set; }

    public string? Description { get; set; }

    public int? TrainerId { get; set; }

    public int? ScheduleId { get; set; }

    public virtual TblSchedule? Schedule { get; set; }

    public virtual ICollection<TblMemberPackage> TblMemberPackages { get; set; } = new List<TblMemberPackage>();

    public virtual TblTrainer? Trainer { get; set; }
}
