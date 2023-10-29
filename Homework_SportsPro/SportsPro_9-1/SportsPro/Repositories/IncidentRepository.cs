using SportsPro.Models;
using SportsPro.Repositories.Interfaces;
using SportsPro;
using Microsoft.EntityFrameworkCore;

namespace SportsPro.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly SportsProContext incidentContextRepository;
       

        public IncidentRepository(SportsProContext context) { 
        
            incidentContextRepository = context;
        }

        // gets all incident
        public IQueryable<Incident> GetAll()
        {
            var incidents = incidentContextRepository.Incidents.Include(p => p.Product)
                                                                .Include(t=>t.Technician)
                                                                .Include(c=>c.Customer);
            return incidents;
        }

        //adds incident
        public void Add(Incident incident)
        {
            incidentContextRepository.Incidents.Add(incident);
        }

        // deletes incident
        public void Delete(int id)
        {
            // find the passed in id in the incidents DB and 
            var incident = incidentContextRepository.Incidents.Find(id);

            //delete incident if found
            if (incident != null) 
            {
                incidentContextRepository.Incidents.Remove(incident); 
            }
        }

        //gets incident by ID
        public Incident GetByID(int id)
        {
            // find the passed in id in the incidents DB and return if found
            var incident = incidentContextRepository.Incidents.Find(id);

            return incident;
          
        }

     

      
        // updates incident
        public void Update(Incident inci)
        {
            var incident = incidentContextRepository.Incidents
                                .FirstOrDefault(i => i.IncidentID == inci.IncidentID);

            // if incident is not null
            //an incident found, update it
            if (inci != null)
            { 
                incidentContextRepository.Incidents.Update(incident);
            }
        }

        //save 
        public void Save()
        {
            incidentContextRepository.SaveChanges();
        }
    }
}
