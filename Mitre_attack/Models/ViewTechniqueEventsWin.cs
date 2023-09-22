using System;
using System.Collections.Generic;

namespace Mitre_attack.Models;

public partial class ViewTechniqueEventsWin
{
    public string? TacticId { get; set; }

    public string? TacticName { get; set; }

    public string? TechniqueId { get; set; }

    public string? TechniqueName { get; set; }

    public string EventId { get; set; } = null!;

    public string? EventName { get; set; }

    public string? EventDescription { get; set; }

    public string? Description { get; set; }
}
