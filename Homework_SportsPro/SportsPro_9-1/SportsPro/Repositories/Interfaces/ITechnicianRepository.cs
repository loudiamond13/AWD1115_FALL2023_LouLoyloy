using SportsPro.Models;

namespace SportsPro.Repositories.Interfaces
{
    public interface ITechnicianRepository
    {
        IQueryable<Technician>  GetAll();

        Technician GetByID(int id);

        void Add(Technician technician);
        void Update(Technician technician);
        void Delete(int id);

        void Save();

    }
}
