using Assignment10.Models;
using Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private BowlingLeagueContext context { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        //index recieves all the parameters it needs to list and sort the teams
        public IActionResult Index(long? teamobject, long? bowlerobject, string teamname, int pageNum = 0)
        {

            //how many players per team
            int pageSize = 5;
            return View(new IndexViewModel
            {
                BowlingLeague = (context.Bowlers
                .Where(m => m.TeamId == bowlerobject || bowlerobject == null)
                .OrderBy(m => m.BowlerLastName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),
                
                Teams = (context.Teams
                .Where(t => t.TeamId == bowlerobject || bowlerobject == null)
                .ToList()),
                
                // creates the page numbering info and sets the class
            PageNumberingInfo = new PageNumberingInfo
            {
                NumItemsPerPage = pageSize,
                CurrentPage = pageNum,
                TotalNumItems = (bowlerobject == null ? context.Bowlers.Count() :
                    context.Bowlers.Where(x => x.TeamId == bowlerobject).Count())
            },
                TeamsName = teamname
           });
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
