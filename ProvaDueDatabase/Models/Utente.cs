

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaDueDatabase.Models
{
    [Table("Utenti")]
    public class Utente
    {
        [Key]
        public string Id { get; set; }

        [Column]
        public string Nome { get; set; }
        
        [Column]
        public string Cognome { get; set; }

        
    }
}
