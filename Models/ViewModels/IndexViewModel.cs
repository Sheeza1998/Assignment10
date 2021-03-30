using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models.ViewModels
{
    //creates all the data that will be sent to the IndexViewModel
    public class IndexViewModel
    {
        public List<Bowlers> BowlingLeague { get; set; }
        public List<Teams> Teams { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string TeamsName { get; set; }
    }
}
