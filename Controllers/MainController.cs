using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuotingDojo.Models
{
    public class MainController : Controller
    {
        // Standard route to index
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }
        // Standard route to view quotes
        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            // Queries the DB for all quotes, add the Dictionary list object in the view return.
            ViewBag.AllQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at DESC");
            return View("Quotes");
        }
        [HttpPost("quotes")]
        public IActionResult Create(Quote quote)
        {
            // if there are no errors in the form submission proceed, else return to index with error messages
            if(ModelState.IsValid)
            {
                // queries the DB to add the form data, along with a timestamp.
                string query = $"INSERT INTO quotes (quote, name, created_at) VALUES ('{quote.QuoteText}', '{quote.Name}', NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("quotes");
            }
            else
            {
                return View("Index");
            }
        }
    }
}