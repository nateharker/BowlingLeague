using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class IndexViewModel  //Class built to bundle all the code needed to send to the view
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string Team { get; set; } //Enables passing of the selected team that's being filtered to be sent to the view
    }
}
