using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace KROS_Pohovor.Models;

public partial class Projekty
{
    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int KodProjektu { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string NazovProjektu { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int? KodRodicaDivizia { get; set; }

    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int? IdVeducehoProjektu { get; set; }

    [JsonIgnore]
    public virtual Zamestnanci? IdVeducehoProjektuNavigation { get; set; }

    [JsonIgnore]
    public virtual Divizie? KodRodicaDiviziaNavigation { get; set; }

    public virtual ICollection<Oddelenium> Oddelenia { get; } = new List<Oddelenium>();
}
