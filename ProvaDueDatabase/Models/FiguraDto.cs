using Newtonsoft.Json;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text.Json;

namespace ProvaDueDatabase.Models
{
    [Serializable]
    public class FiguraDto
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public byte[] Immagine { get; set; }

        [JsonProperty]
        public string Descrizione { get; set; }

        public FiguraDto()
        {

        }
        public FiguraDto(int id, byte[] immagine)
        {
            Id = id;
            Immagine = immagine;
        }

        public FiguraDto(int id, byte[] immagine, string descrizione)
        {
            Id = id;
            Immagine = immagine;
            Descrizione = descrizione;
        }


        public string To64Imagine()
        {   
                return string.Format("data:image/jpeg; base64,{0}", Convert.ToBase64String(Immagine));   
        }
    }


}
