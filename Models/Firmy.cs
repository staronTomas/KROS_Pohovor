using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KROS_Pohovor.Models;

public partial class Firmy
{
    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int KodFirmy { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string NazovFirmy { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int? IdRiaditela { get; set; }

    public virtual ICollection<Divizie> Divizies { get; } = new List<Divizie>();

    [JsonIgnore]
    public virtual Zamestnanci? IdRiaditelaNavigation { get; set; }

    public virtual ICollection<Zamestnanci> Zamestnancis { get; } = new List<Zamestnanci>();
}
