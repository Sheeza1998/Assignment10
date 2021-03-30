using Assignment10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Components
{
    public class TeamNameViewComponent : ViewComponent
    {
        //creates the context for program
        private BowlingLeagueContext context;
        public TeamNameViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        //
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["teamname"];

            //makes sure the teams are distinct and passes the context to where it will list the teams out
            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
