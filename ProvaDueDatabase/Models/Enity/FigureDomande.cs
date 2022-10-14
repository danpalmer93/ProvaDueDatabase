using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ProvaDueDatabase.Models.Enity
{
    [Table("Figure_Domande")]
    public class FigureDomande
    {
        [Key]
        public int Id { get; set; }
        [Column("id_figura")]
        public int IdFigura { get; set; }

        [Column("id_domanda")]
        [Required]
        public int IdDomanda { get; set; }
    }
}
