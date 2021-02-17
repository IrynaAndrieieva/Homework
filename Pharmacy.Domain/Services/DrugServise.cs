using Pharmacy.Data;
using Pharmacy.Data.Repositories;
using Pharmacy.Data.Repositories.Interfaces;
using Pharmacy.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace Pharmacy.Domain.Models
{
    public class DrugServise : IDrugService
    {
        public readonly IDrugsRepository _drugsRepository;

        public DrugServise(IDrugsRepository drugsRepository)
        {
            _drugsRepository = drugsRepository;
        }

        public DrugModel Create(DrugModel model)
        {
            var drug = new Drug
            {
                Name = model.Name,
                MedicinalSubstance = model.MedicinalSubstance,
                FormId = model.FormId
            };
            _drugsRepository.Create(drug);
            model.Id = drug.Id;

            return model;
        }

        public IEnumerable<DrugModel> GetAll()
        {
            var drugs = _drugsRepository.GetAll();

            var result = new List<DrugModel>();

            foreach (var drug in drugs)
            {
                result.Add(new DrugModel
                {
                    Id = drug.Id,
                    Name = drug.Name,
                    MedicinalSubstance = drug.MedicinalSubstance,
                    FormId = drug.FormId

                });
            }

            return result;
        }
    }
}
