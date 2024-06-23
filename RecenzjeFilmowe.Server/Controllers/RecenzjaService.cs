using RecenzjeFilmowe.Server.DataAccess;
using RecenzjeFilmowe.Server.DataAccess.Entities;
using RecenzjeFilmowe.Server.Interfaces;

namespace RecenzjeFilmowe.Server.Controllers
{
    public class RecenzjaService : IRecenzjaService
    {
        private readonly AppDbContext _context;
        public RecenzjaService(AppDbContext context)
        {
            _context = context;
        }
        public void AddRecenzja(Recenzja recenzja)
        {   
            recenzja.Data = DateTime.Now;
            _context.Recenzje.Add(recenzja);
            _context.SaveChanges();
        }

        public IEnumerable<Recenzja> GetRecenzja(int Id)
        {
            return _context.Recenzje.Where(o => o.FilmId == Id).Select(recenzja => new Recenzja
            {
                Id = recenzja.Id,
                Autor = recenzja.Autor,
                Data = recenzja.Data,
                Ocena = recenzja.Ocena,
                Tekst = recenzja.Tekst,
                FilmId = recenzja.FilmId,
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
