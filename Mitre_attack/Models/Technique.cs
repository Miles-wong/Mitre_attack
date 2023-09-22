using System;
using System.Collections.Generic;

namespace Mitre_attack.Models;

public partial class Technique
{
    public string TechniqueId { get; set; } = null!;

    public string TechniqueName { get; set; } = null!;

    public string TacticId { get; set; } = null!;

    public string? SubTechniqueOf { get; set; }

    public string? Description { get; set; }
}
