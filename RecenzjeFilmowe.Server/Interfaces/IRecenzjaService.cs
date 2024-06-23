using RecenzjeFilmowe.Server.DataAccess.Entities;

namespace RecenzjeFilmowe.Server.Interfaces
{
    public interface IRecenzjaService
    {
        IEnumerable<Recenzja> GetRecenzja(int Id);
        void AddRecenzja(Recenzja recenzja);
    }
}
