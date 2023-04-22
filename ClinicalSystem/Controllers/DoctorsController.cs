using ClinicalSystem.Entities;
using ClinicalSystem.Models;
using ClinicalSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClinicalSystem.Controllers
{
    public class DoctorsController : Controller
    {
        public IDoctorServices services;

        public DoctorsController(IDoctorServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<DoctorViewModel> doctors = services.listing();
            return View(doctors);
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            if (ModelState.IsValid)
                return View(services.getDoctor(ID));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorViewModel doctor)
        {
            try
            {
                services.Create(doctor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            if (ID > 0) return View(services.getDoctor(ID));
            else return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoctorViewModel doctor)
        {
            try
            {
                services.Update(doctor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            services.Delete(ID);
            return RedirectToAction(nameof(Index));
        }

    }
}
