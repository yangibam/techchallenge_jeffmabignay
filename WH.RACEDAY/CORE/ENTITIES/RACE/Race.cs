using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RACEDAY.CORE.ENTITIES.RACE
{
    public class Race
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Start { get; set; }
        public string Status { get; set; }
        public List<Horse> Horses { get; set; }
    }
}
