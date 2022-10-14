using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ProvaDueDatabase.Models.Enity
{
    [Table("Risposte")]
    public class Risposta
    {
        [Key]
        public int Id { get; set; }

        [Column ("testo")]
        [Required]
        public string TestoRisposta { get; set; }

        [Column("id_fig_dom")]
        [Required]
        public int IdFiguraDomanda { get; set; }

        [Column]
        public int Peso { get; set; }
    }
}
