using Pharmacy.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pharmacy.Data.Repositories
{
    public class DrugsAdoNetRepository : IDrugsRepository
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=Pharmacy;Integrated Security=True";

        public Drug Create(Drug model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "INSERT INTO Drugs(Name,MedicinalSubstance,FormId) OUTPUT INSERTED.id VALUES(@Name,@MedicinalSubstance,@FormId)";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@MedicinalSubstance", model.MedicinalSubstance);
                command.Parameters.AddWithValue("@FormId", model.FormId);
                

                connection.Open();

                var drugId = command.ExecuteScalar();

                var drugIdInt = Convert.ToInt32(drugId);
                model.Id = drugIdInt;

                return model;
            }
        }

        public IEnumerable<Drug> GetAll()
        {
            var result = new List<Drug>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "SELECT * FROM Drugs";
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Drug
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        MedicinalSubstance = reader.GetString(2),
                        FormId = reader.GetInt32(3)
                    });
                }
                reader.Close();

                return result;
            }
        }
    }
}
