using BowlingLeague.Models;
using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            _context = context; /*Repository is assigned a value here so that it can be accessed within the controller*/
        }

        public IActionResult Index(long? teamId, string teamName, int pageNum = 1)
        {
            int pageSize = 5; //Adjust this number to change how many records are displayed on each page
            ViewBag.SelectedTeam = teamName;

            return View(new IndexViewModel
            {
                Bowlers = _context.Bowlers //Helps determine which records to send to the view based on the page it's on
                .Where(t => t.TeamId == teamId || teamId == null) //Filters by category, if arguement is passed to function
                .OrderBy(t => t.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize) //Based on page button pressed, determines which records to show
                .Take(pageSize)
                .ToList(),

                PageNumberingInfo = new PageNumberingInfo //Helps determine how many pages there should be total
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //If no meal type has been selected, get full count, otherwise, only count the number of selected meal type
                    TotalNumItems = (teamId == null ? _context.Bowlers.Count() : _context.Bowlers.Where(x => x.TeamId == teamId).Count())
                },

                Team = teamName
            });
            /*Books are sent to the Index page to be used there*/
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
