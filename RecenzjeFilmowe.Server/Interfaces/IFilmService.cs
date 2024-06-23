using RecenzjeFilmowe.Server.DataAccess.Entities;

namespace RecenzjeFilmowe.Server.Interfaces
{
    public interface IFilmService
    {
        IEnumerable<Film> GetFilm();
        IEnumerable<Film> GetFilm(String tytul);
        Film? GetFilm(int ID);
    }
}
