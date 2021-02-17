using System.Collections.Generic;

namespace Pharmacy.Domain.Services.Interfaces
{
    public interface IDrugService
    {
        IEnumerable<DrugModel> GetAll();
        DrugModel Create(DrugModel model);
    }
}
