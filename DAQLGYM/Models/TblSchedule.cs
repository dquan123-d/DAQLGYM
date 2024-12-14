using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblSchedule
{
    public int ScheduleId { get; set; }

    public int? TrainerId { get; set; }

    public int? RoomId { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? DayOfWeek { get; set; }

    public string? Describe { get; set; }

    public virtual TblRoom? Room { get; set; }

    public virtual ICollection<TblClass> TblClasses { get; set; } = new List<TblClass>();

    public virtual TblTrainer? Trainer { get; set; }
}
