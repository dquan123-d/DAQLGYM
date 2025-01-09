using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblTrainer
{
    public int TrainerId { get; set; }

    public string? FullName { get; set; }


    public int? Experience { get; set; }

    public string? ContactInfo { get; set; }

    public string? ProfileImage { get; set; }


    public virtual ICollection<TblClass> TblClasses { get; set; } = new List<TblClass>();

    public virtual ICollection<TblSchedule> TblSchedules { get; set; } = new List<TblSchedule>();
}
