using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaDueDatabase.Models
{
    [Table("Domande")]
    public class Domanda
    {
        public Domanda()
        {

        }

        public Domanda(string testo, int? @default)
        {
            Testo = testo;
            Default = @default;
        }

        public Domanda(int id, string testo, int? @default)
        {
            Id = id;
            Testo = testo;
            Default = @default;
        }

        [Key]   
        public int Id { get; set; }

        [Required]
        public string Testo { get; set; }

        public int? Default { get; set; }
    }
}
