using System;
using System.Collections.Generic;

namespace DAQLGYM.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public int? TrainerId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? ImageBlog { get; set; }

    public virtual TblTrainer? Trainer { get; set; }
}
