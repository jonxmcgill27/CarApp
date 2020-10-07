using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    public class BuySellController : Controller
    {
        // GET: BuySellController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BuySellController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BuySellController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuySellController/Create
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

        // GET: BuySellController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BuySellController/Edit/5
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

        // GET: BuySellController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BuySellController/Delete/5
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
