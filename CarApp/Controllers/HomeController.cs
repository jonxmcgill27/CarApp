using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarApp.DataAccess.Data.Repositories;
using CarApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CarApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        // private readonly ILogger<HomeController> _logger;
        /*ILogger<HomeController> logger*/
        //_logger = logger;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }

        public IActionResult Index()
        {
            string imgDataURL = null;
            var events = _unitOfWork.Event.GetAll();
            List<EventGatheringVM> eventVMs = new List<EventGatheringVM>();
            foreach(var item in events)
            {
                EventGatheringVM eventVM = new EventGatheringVM();
                eventVM.Title = item.Title;
                eventVM.DateStart = item.DateStart;
                eventVM.DateEnd = item.DateEnd;
                eventVM.Description = item.Description;

                string imreBase64Data = Convert.ToBase64String(item.Image);
                imgDataURL = string.Format("data:image;base64,{0}", imreBase64Data);

                eventVM.ImageFormatted = imgDataURL;
                eventVMs.Add(eventVM);
                
            }


            ViewBag.ImageData = imgDataURL;
            return View(eventVMs);
        }

        public IActionResult EventForm()
        {
            return View(new EventGatheringVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitEventForm(EventGatheringVM model)
        {
            
            if (ModelState.IsValid)
            {

                EventGathering eventForDb = new EventGathering();
                eventForDb.Title = model.Title;
                eventForDb.DateStart = model.DateStart;
                eventForDb.DateEnd = model.DateEnd;
                eventForDb.DateCreated = DateTime.Now;
                eventForDb.Description = model.Description;
               
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    var stream = model.Image.OpenReadStream();
                    stream.CopyTo(ms);
                    fileBytes = ms.ToArray();
                    stream.Dispose();
                }

                eventForDb.Image = fileBytes;

                _unitOfWork.Event.Add(eventForDb);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(EventForm));
        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
