using Pharmacy.Data.Models;
using System.Collections.Generic;

namespace Pharmacy.Data
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MedicinalSubstance { get; set; }

        public int FormId { get; set; } // отделенные 
        public virtual Form Form { get; set; } // внешние ключи

    }
}
