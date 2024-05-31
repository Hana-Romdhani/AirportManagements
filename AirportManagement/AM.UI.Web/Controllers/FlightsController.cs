using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace AM.UI.Web.Controllers
{
    public class FlightsController : Controller

    {

        private readonly IServiceFlight serviceFlight;
        private readonly IServicePlane _planeService;

        public FlightsController(IServiceFlight serviceFlight, IServicePlane _planeService)
        {
            this.serviceFlight = serviceFlight;
            this._planeService = _planeService;
        }

        // GET: FlightsController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                return View(serviceFlight.GetAll().ToList());
            else
                return
                View(serviceFlight.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());
        }


        public ActionResult Sort()
        {
            return View("Index", serviceFlight.SortFlights());
        }

        // GET: FlightsController/Details/5
        public ActionResult Details(int id)
        {
            Flight flight = serviceFlight.GetById(id);
            return View(flight);
        }

        // GET: FlightsController/Create
        public ActionResult Create()
        {
          
                ViewBag.Planes = new SelectList(_planeService.GetAll().ToList(),
                "PlaneId", "PlaneId");
                return View();
            
        }

        // POST: FlightsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Create(Flight flight, IFormFile PilotImage)
        {
            try
            {
                if (PilotImage != null)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + PilotImage.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        PilotImage.CopyTo(stream);
                    }
                    flight.Pilot = uniqueFileName; 
                }

                serviceFlight.Add(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightsController/Edit/5
        public ActionResult Edit(int id)
        {        Flight flight = serviceFlight.GetById(id);
            
            return View(flight);
        }

        // POST: FlightsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection)
        {
            try
            {
                serviceFlight.Update(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightsController/Delete/5
        public ActionResult Delete(int id)

        {
            Flight flight = serviceFlight.GetById(id);
                    
            return View(flight);
        }

        // POST: FlightsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Flight collection)
        {
            try
            {
                serviceFlight.Delete(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
     
    }
}
