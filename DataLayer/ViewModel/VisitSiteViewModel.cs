using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
   public class VisitSiteViewModel
    {
        public int VisitToday { get; set; }
        public int VisitYesterday { get; set; }
        public int VisitSum { get; set; }
        public int Online { get; set; }
    }
}
