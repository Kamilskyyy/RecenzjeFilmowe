using Microsoft.EntityFrameworkCore;
using RecenzjeFilmowe.Server.DataAccess;
using RecenzjeFilmowe.Server.DataAccess.Entities;
using RecenzjeFilmowe.Server.Interfaces;

namespace RecenzjeFilmowe.Server.Controllers
{
    public class FilmService : IFilmService
    {
        private readonly AppDbContext _context;
        public FilmService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Film> GetFilm()
        {
            return _context.Filmy.Select(film => new Film
            {
                Id = film.Id,
                Tytul = film.Tytul,
                Premiera = film.Premiera,
                Czas = film.Czas,
                Rezyseria = film.Rezyseria,
                Zdjecie = film.Zdjecie,
                Link = film.Link
            }).OrderBy(o => o.Tytul).ToList();
        }

        public IEnumerable<Film> GetFilm(String tytul)
        {
            return _context.Filmy.Where(o => o.Tytul.Contains(tytul)).Select(film => new Film
            {
                Id = film.Id,
                Tytul = film.Tytul,
                Premiera = film.Premiera,
                Czas = film.Czas,
                Rezyseria = film.Rezyseria,
                Zdjecie = film.Zdjecie,
                Link = film.Link
            }).OrderBy(o => o.Tytul).ToList();
        }

        public Film? GetFilm(int ID)
        {
            var film = _context.Filmy.FirstOrDefault(o => o.Id == ID);
            if (film == null) { return null; }
            return
                new Film
                {
                    Id = film.Id,
                    Tytul = film.Tytul,
                    Premiera = film.Premiera,
                    Czas = film.Czas,
                    Rezyseria = film.Rezyseria,
                    Zdjecie = film.Zdjecie,
                    Link = film.Link
                };
        }
    }
}
