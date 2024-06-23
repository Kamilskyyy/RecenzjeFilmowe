using System.ComponentModel.DataAnnotations.Schema;

namespace RecenzjeFilmowe.Server.DataAccess.Entities
{
    public class Film
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Tytul { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Premiera { get; set; }

        public int Czas { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Rezyseria { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Zdjecie { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Link { get; set; }
        public virtual List<Recenzja> Recenzje { get; set; } = [];
    }
}
