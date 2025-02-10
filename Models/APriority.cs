using System;
using System.Collections.Generic;

namespace TaskManagerApp_Bunya.Models;

public partial class APriority
{
    public int PriorityId { get; set; }

    public string? Priority { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
