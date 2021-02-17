using Pharmacy.Domain.Models;

namespace Pharmacy.Domain
{
    public class DrugModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MedicinalSubstance { get; set; }
        public int FormId { get; set; }

        public FormModel Form { get; set; }
    }
}
