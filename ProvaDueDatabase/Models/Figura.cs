using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaDueDatabase.Models
{
    [Table("Figure")]
    public class Figura
    {
        [Key]   
        public int Id { get; set; }
        [Required]
        public byte[] File { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [Required]
        public string File_Name { get; set; }
    }
}
