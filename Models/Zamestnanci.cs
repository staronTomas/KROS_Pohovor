using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KROS_Pohovor.Models;

public partial class Zamestnanci
{
    [Required]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Meno { get; set; } = null!;

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Priezvisko { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Titul { get; set; } = null!;

    [Required(AllowEmptyStrings =true)]
    [StringLength(50, MinimumLength = 2)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(50, MinimumLength = 2)]
    [Phone]
    public string TelefonneCislo { get; set; } = null!;

    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
    public int? IdFirmyZamestnanca { get; set; }

    public virtual ICollection<Divizie> Divizies { get; } = new List<Divizie>();

    public virtual ICollection<Firmy> Firmies { get; } = new List<Firmy>();


    [JsonIgnore]
    public virtual Firmy? IdFirmyZamestnancaNavigation { get; set; }

    public virtual ICollection<Oddelenium> Oddelenia { get; } = new List<Oddelenium>();

    public virtual ICollection<Projekty> Projekties { get; } = new List<Projekty>();
}
