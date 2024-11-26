using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblComment
{
    public int CommentId { get; set; }

    public int? MemberId { get; set; }

    public int? ServiceId { get; set; }

    public string? Comment { get; set; }

    public int? ReplyTo { get; set; }

    public virtual TblMember? Member { get; set; }

    public virtual TblService? Service { get; set; }
}
