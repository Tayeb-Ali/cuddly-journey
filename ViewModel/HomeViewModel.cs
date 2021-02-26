using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Saidality.Models;

namespace Saidality.ViewModel
{
    public class HomeViewModel
    {
        public List<Medicine> Mediciene { get; set; }
        //public Medicine GetMedicines { get; set; }
        public Order Order { get; set; }
        public Locaton Locaton { get; set; }
        public Pharmcy Pharmcy { get; set; }
        public Medicine Medicine { get; set; }

        //public IEnumerable<Medicine> Medicines { get; set; }
        //public IEnumerable<Locaton> Locatons { get; set; }
        //public IEnumerable<Pharmcy> Pharmcy { get; set; }


    }
}
