using System;
using System.Collections.Generic;

namespace TaskManagerApp_Bunya.Models;

public partial class AStatus
{
    public int StatusId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
