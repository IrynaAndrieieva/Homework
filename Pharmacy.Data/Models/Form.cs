using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data.Models
{
    public class Form
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Drug> Drugs { get; set; }

        public Form()
        {
            Drugs = new List<Drug>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
