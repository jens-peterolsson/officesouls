using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itbudet.OfficeSouls.Domain
{
    public class Mood
    {
        public int Now { get; set; }
        public int Today { get; set; }
        public int Week { get; set; }
        public int Month { get; set; }
        public int Season { get; set; }
        public int Year { get; set; }
        public int LastFiveYears { get; set; }
        public int Eternity { get; set; }
    }
}
