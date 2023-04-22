using ClinicalSystem.Models;
using ClinicalSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalSystem.Controllers
{
    public class PatientsController : Controller
    {
        public IPatientServices services;

        public PatientsController(IPatientServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<PatientViewModel> patients = services.listing();
            return View(patients);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientViewModel patient)
        {
            try
            {
                services.Create(patient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int dni)
        {
            if(ModelState.IsValid)
                return View(services.getPatient(dni));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int dni)
        {
            if (dni > 0) return View(services.getPatient(dni));
            else return RedirectToAction(nameof(Index));
        }

        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientViewModel patient)
        {
            try
            {
                services.Update(patient);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int DNI)
        {
            services.Delete(DNI);
            return RedirectToAction(nameof(Index));

        }
    }
}
