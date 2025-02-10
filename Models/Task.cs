using System;
using System.Collections.Generic;

namespace TaskManagerApp_Bunya.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? Status { get; set; }

    public DateTime? DueDate { get; set; }

    public int? Priority { get; set; }

    public DateTime? CreationTimestamp { get; set; }

    public DateTime? LastUpdatedTimestamp { get; set; }

    public virtual APriority? PriorityNavigation { get; set; }

    public virtual AStatus? StatusNavigation { get; set; }
}
