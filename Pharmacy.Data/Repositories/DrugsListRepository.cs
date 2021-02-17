using Pharmacy.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace Pharmacy.Data.Repositories
{
    public class DrugsListRepository : IDrugsRepository
    {
        private readonly IList<Drug> _drugs;

        public DrugsListRepository()
        {
            _drugs = new List<Drug>();

            for (int i = 0; i < 10; i++)
            {
                _drugs.Add(new Drug
                {
                    Id = i,
                    Name = $"Name_{i}",
                    MedicinalSubstance = "MedicinalSubstance_{i}",
                    FormId = i+1,
                });
            }
        }
        public Drug Create(Drug model)
        {
            model.Id = _drugs.Count;

            _drugs.Add(model);

            return model;
        }

        public IEnumerable<Drug> GetAll()
        {
            return _drugs;
        }
    }
}
