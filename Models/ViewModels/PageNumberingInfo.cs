using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        public int NumPages => (int)(Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage));     //Funtion to determine how many whole pages are needed 
                                                                                                  //to diplay all the records with the given number of records 
                                                                                                  //per page.

    }
}
