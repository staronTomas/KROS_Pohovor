using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KROS_Pohovor.Models;

public partial class Oddelenium
{
    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int KodOddelenia { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string NazovOddelenia { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int? KodRodicaProjekt { get; set; }

    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int? IdVeducehoOddelenia { get; set; }

    [JsonIgnore]
    public virtual Zamestnanci? IdVeducehoOddeleniaNavigation { get; set; }

    [JsonIgnore]
    public virtual Projekty? KodRodicaProjektNavigation { get; set; }
}
