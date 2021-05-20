using Microsoft.AspNetCore.Mvc;
using Navimod.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navimod.Web.Controllers
{
    public class QuoteController : Controller
    {
        QuoteServices quoteServices = new QuoteServices();
        public ActionResult List()
        {
            return View(quoteServices.Quotes.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                quoteServices.SaveQuote(quote);
                return RedirectToAction("List");
            }
            return View();

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Quote quote = quoteServices.Quotes.Single(e => e.Id == id);
            return View(quote);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Quote quote = quoteServices.Quotes.Single(e => e.Id == id);
            return View(quote);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Quote quote = quoteServices.Quotes.Single(e => e.Id == id);
            return View(quote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete_Confirm(int id)
        {
            if (ModelState.IsValid)
            {
                quoteServices.DeleteQuote(id);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}
