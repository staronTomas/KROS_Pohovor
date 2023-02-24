using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KROS_Pohovor.Models;

public partial class Divizie
{
    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int KodDivizie { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string NazovDivizie { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int? KodRodicaFirma { get; set; }

    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int? IdVeducehoDivizie { get; set; }

    [JsonIgnore]
    public virtual Zamestnanci? IdVeducehoDivizieNavigation { get; set; }

    [JsonIgnore]
    public virtual Firmy? KodRodicaFirmaNavigation { get; set; }

    public virtual ICollection<Projekty> Projekties { get; } = new List<Projekty>();
}
