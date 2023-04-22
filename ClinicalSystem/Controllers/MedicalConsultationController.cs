using ClinicalSystem.Models;
using ClinicalSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalSystem.Controllers
{
    public class MedicalConsultationController : Controller
    {
        public IMedicalConsultationServices services;

        public MedicalConsultationController(IMedicalConsultationServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<MedicalConsultationViewModel> list = services.listing();
            return View(list);
        }

        // GET: MedicalConsultationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalConsultationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicalConsultationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicalConsultationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicalConsultationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicalConsultationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
