using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarApp.DataAccess.Data.Repositories;
using CarApp.Models;
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
            foreach(var item in events)
            {
                string imreBase64Data = Convert.ToBase64String(item.Image);
                imgDataURL = string.Format("data:image;base64,{0}", imreBase64Data);
            }

            ViewBag.ImageData = imgDataURL;
            return View(events);
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
