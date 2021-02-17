using Dapper;
using Pharmacy.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pharmacy.Data.Repositories
{
    public class DrugsDapperRepository : IDrugsRepository
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=Pharmacy;Integrated Security=True";

        public Drug Create(Drug model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = $"INSERT INTO Drugs(Name,MedicinalSubstance,FormId) OUTPUT INSERTED.id VALUES(\'{model.Name}\',\'{model.MedicinalSubstance}\',{model.FormId})";

                var insetredId = connection.ExecuteScalar(queryString);
                var insetredIdInt = Convert.ToInt32(insetredId);
                model.Id = insetredIdInt;

                return model;
            }
        }

        public IEnumerable<Drug> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                return connection.Query<Drug>("SELECT * FROM Drugs");
            }
        }
    }
}
