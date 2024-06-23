using System.ComponentModel.DataAnnotations.Schema;

namespace RecenzjeFilmowe.Server.DataAccess.Entities
{
    public class Recenzja
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Autor { get; set; }
        public DateTime Data { get; set; }
        public int Ocena { get; set; }
        public string Tekst { get; set; }
        public int FilmId { get; set; }
        public virtual Film? Film { get; set; }
    }
}
