using System;
using System.Collections.Generic;

namespace Mitre_attack.Models;

public partial class ViewTechniquePlatform
{
    public string TacticId { get; set; } = null!;

    public string TacticName { get; set; } = null!;

    public string TechniqueId { get; set; } = null!;

    public string TechniqueName { get; set; } = null!;

    public uint PlatformId { get; set; }

    public string PlatformName { get; set; } = null!;
}
