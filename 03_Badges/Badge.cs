using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public List<string> ListOfDoorNames { get; set; }

        public Badge() { }
        public Badge(int badgeId, List<string> listOfDoorNames)
        {
            BadgeId = badgeId;
            ListOfDoorNames = listOfDoorNames;
        }
    }
}
