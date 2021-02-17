using System.Collections.Generic;

namespace Pharmacy.Data.Repositories.Interfaces
{
    public interface IDrugsRepository
    {
        IEnumerable<Drug> GetAll();
        Drug Create(Drug model);
    }
}
