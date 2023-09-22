using System;
using System.Collections.Generic;

namespace Mitre_attack.Models;

public partial class TechniqueEventsWin
{
    public string EventId { get; set; } = null!;

    public string TechniqueId { get; set; } = null!;

    public string? Description { get; set; }
}
