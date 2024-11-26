using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblRoom
{
    public int RoomId { get; set; }

    public string? RoomName { get; set; }

    public int? Capacity { get; set; }

    public string? Equipment { get; set; }

    public virtual ICollection<TblEquipment> TblEquipments { get; set; } = new List<TblEquipment>();

    public virtual ICollection<TblSchedule> TblSchedules { get; set; } = new List<TblSchedule>();
}
