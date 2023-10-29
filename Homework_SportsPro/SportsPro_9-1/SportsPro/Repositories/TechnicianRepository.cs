using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using SportsPro.Repositories.Interfaces;

namespace SportsPro.Repositories
{
    public class TechnicianRepository : ITechnicianRepository
    {
        private SportsProContext technicianContextRepository;

        public TechnicianRepository(SportsProContext context)
        {
            technicianContextRepository = context;
        }

        public IQueryable<Technician> GetAll()
        {
            var technicians = technicianContextRepository.Technicians;
            return technicians;
        }

        public void Add(Technician technician)
        {
            technicianContextRepository.Technicians.Add(technician);
        }

        public void Delete(int id)
        {
            var technician = technicianContextRepository.Technicians.Find(id);

            if (technician != null) 
            {
                technicianContextRepository.Technicians.Remove(technician);
            }
        }

  

        public Technician GetByID(int id)
        {
            var technician = technicianContextRepository.Technicians.Find(id);
            return technician;
        }

  

        public void Update(Technician tech)
        {
            //var technician = technicianContextRepository.Technicians.Find(tech.TechnicianID);

            if (tech != null) 
            {
                technicianContextRepository.Technicians.Update(tech);
            }

        }
        public void Save()
        {
            technicianContextRepository.SaveChanges();
        }
    }
}
