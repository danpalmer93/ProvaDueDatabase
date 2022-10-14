namespace ProvaDueDatabase.Models.Dto
{
    public class DomandaDto
    {
        public DomandaDto()
        {

        }

        public DomandaDto(string testoDomanda, int? @default)
        {
            TestoDomanda = testoDomanda;
            Default = @default;
        }

        public DomandaDto(int id, string testoDomanda, int? @default)
        {
            Id = id;
            TestoDomanda = testoDomanda;
            Default = @default;
        }

        public int Id { get; set; }

        public string TestoDomanda { get; set; }

        public int? Default { get; set; }
    }
}
