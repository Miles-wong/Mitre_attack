using System;
using System.Collections.Generic;

namespace Mitre_attack.Models;

public partial class WindowsEvent
{
    public string EventId { get; set; } = null!;

    public string? Description { get; set; }

    public string? EventName { get; set; }
}
