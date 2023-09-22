using System;
using System.Collections.Generic;

namespace Mitre_attack.Models;

public partial class Tactic
{
    public string TacticId { get; set; } = null!;

    public string TacticName { get; set; } = null!;

    public string? Description { get; set; }
}
