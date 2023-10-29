using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SportsPro.Models;
using SportsPro.Models.Validations;
using SportsPro.Models.ViewModels;
using SportsPro.Repositories.Interfaces;

namespace SportsPro.Controllers
{
    public class UpdateIncidentController : Controller
    {
        private  IIncidentRepository incidentContextRepository;
        private  ITechnicianRepository technicianContextRepository;


        public UpdateIncidentController(SportsProContext asd, IIncidentRepository contextI, ITechnicianRepository contextT)
        {

            incidentContextRepository = contextI;
            technicianContextRepository = contextT;
        }



        [Route("/update-incident/select-tech/{id?}")]
        public IActionResult SelectTech(int id)
        {
            var technicians = technicianContextRepository.GetAll();

            ViewBag.Technicians = technicianContextRepository.GetAll().ToList();
            return View();

        }




        [HttpPost]
        [Route("/update-incident/{action?}/{id?}")]
        public IActionResult List(Technician technician)
        {
            ViewBag.Tech = technician.Name;


            IncidentViewModel incidentViewModel = new IncidentViewModel();

            //gets the incident associated to the selected tech
            incidentViewModel.Incidents = incidentContextRepository.GetAll()
                          .Where(i => i.TechnicianID == technician.TechnicianID)
                          .ToList();

            //if incident is empty let the user know
            if (incidentViewModel.Incidents.IsNullOrEmpty())
            {
                TempData["message"] = "Selected Technician Has No Incident Assigned";
                return RedirectToAction("SelectTech");
            }
            // if there is incident found for the selected tech, show
            else {
                return View("List", incidentViewModel);
            }





        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            
            ViewBag.Incident = incidentContextRepository.GetAll()
                                                .Include(i => i.Technician)
                                                .Include(i => i.Customer)
                                                .Include(i => i.Product)
                                                .ToList(); ;


            var inc = incidentContextRepository.GetByID(id);
            return View("Edit",inc);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            ViewBag.Incident = incident;

            if (incident != null)
            {
                incidentContextRepository.Update(incident);
            }

            


            incidentContextRepository.Save();

          return RedirectToAction("SelectTech","UpdateIncident");
        }


    }
}
