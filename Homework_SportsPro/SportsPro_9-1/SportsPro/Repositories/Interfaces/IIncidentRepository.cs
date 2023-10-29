using SportsPro.Models;

namespace SportsPro.Repositories.Interfaces
{
    public interface IIncidentRepository 
    {
        IQueryable<Incident> GetAll();

        Incident GetByID(int id);

        void Add(Incident incident);

        void Update(Incident incident); 

        void Delete(int id);
        
        void Save();
    }
}
