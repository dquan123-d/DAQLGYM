using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblEquipment
{
    public int EquipmentId { get; set; }

    public string? EquipmentName { get; set; }

    public string? DeviceType { get; set; }

    public string? Brand { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public string? StatusEquipment { get; set; }

    public string? LocationEquipment { get; set; }

    public int? AssignedRoomId { get; set; }

    public virtual TblRoom? AssignedRoom { get; set; }
}
