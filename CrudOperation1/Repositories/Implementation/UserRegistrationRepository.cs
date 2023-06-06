using CrudOperation1.Models;
using CrudOperation1.Repositories.Contract;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace CrudOperation1.Repositories.Implementation
{
    public class UserRegistrationRepository : IGenericRepository<TblUserRegistration>
    {
       private readonly IConfiguration _configuration;
        public UserRegistrationRepository(IConfiguration  configuration)
        {
                _configuration = configuration;
        }

        public async Task<List<TblUserRegistration>> GetList()
        {
            List<TblUserRegistration> TblUserRegistrations = new List<TblUserRegistration>();
            using (var connetion = new SqlConnection(_configuration.GetConnectionString("CrudOperationMegaminds")))
            {
                connetion.Open();
                SqlCommand cmd = new SqlCommand("Sp_ListtblUserRegistration", connetion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        
                        TblUserRegistrations.Add(new TblUserRegistration
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Name = dr["Name"].ToString(),
                            Email = dr["Email"].ToString(),
                            Phone = Convert.ToInt64(dr["Phone"].ToString()),
                            Address = dr["Address"].ToString(),
                          

                        });
                    }
                   
                }
            }
            return TblUserRegistrations;
           
        }

        public async Task<bool> Save(TblUserRegistration entity)
        {
            List<TblUserRegistration> TblUserRegistrations = new List<TblUserRegistration>();
            using (var connetion = new SqlConnection(_configuration.GetConnectionString("CrudOperationMegaminds")))
            {
                connetion.Open();
                SqlCommand cmd = new SqlCommand("Sp_SavetblUserRegistration", connetion);
                cmd.Parameters.AddWithValue("Name",entity.Name);
                cmd.Parameters.AddWithValue("Email",entity.Email);
                cmd.Parameters.AddWithValue("Phone",entity.Phone);
                cmd.Parameters.AddWithValue("Address",entity.Address);
                cmd.Parameters.AddWithValue("State_Id", entity.StateId);
                cmd.Parameters.AddWithValue("City_Id", entity.CityId);
                cmd.CommandType = CommandType.StoredProcedure;

               int affectedRows= await cmd.ExecuteNonQueryAsync();

                if(affectedRows > 0) 
                    return true;
                else 
                    return false;
            }
        }
      

        public async Task<bool> Edit(TblUserRegistration entity)
        {
            List<TblUserRegistration> TblUserRegistrations = new List<TblUserRegistration>();
            using (var connetion = new SqlConnection(_configuration.GetConnectionString("CrudOperationMegaminds")))
            {
                connetion.Open();
                SqlCommand cmd = new SqlCommand("Sp_EdittblUserRegistration", connetion);
                cmd.Parameters.AddWithValue("Id", entity.Id);
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Email", entity.Email);
                cmd.Parameters.AddWithValue("Phone", entity.Phone);
                cmd.Parameters.AddWithValue("Address", entity.Address);
                cmd.Parameters.AddWithValue("State_Id", entity.StateId);
                cmd.Parameters.AddWithValue("City_Id", entity.CityId);
                cmd.CommandType = CommandType.StoredProcedure;

                int affectedRows = await cmd.ExecuteNonQueryAsync();

                if (affectedRows > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            List<TblUserRegistration> TblUserRegistrations = new List<TblUserRegistration>();
            using (var connetion = new SqlConnection(_configuration.GetConnectionString("CrudOperationMegaminds")))
            {
                connetion.Open();
                SqlCommand cmd = new SqlCommand("Sp_DeletetblUserRegistration", connetion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                int affectedRows = await cmd.ExecuteNonQueryAsync();

                if (affectedRows > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<TblUserRegistration> GetById(int id)
        {
            TblUserRegistration TblUserRegistrations = new TblUserRegistration();
            using (var connetion = new SqlConnection(_configuration.GetConnectionString("CrudOperationMegaminds")))
            {
                connetion.Open();
                SqlCommand cmd = new SqlCommand("Sp_SingletblUserRegistration", connetion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       
                        TblUserRegistrations.Id = Convert.ToInt32( reader["Id"]);
                        TblUserRegistrations.Name = (string)reader["Name"];
                        TblUserRegistrations.Email = (string)reader["Email"];
                        TblUserRegistrations.Phone =Convert.ToInt64(reader["Phone"]);
                        TblUserRegistrations.Address = (string)reader["Address"];
                        TblUserRegistrations.StateId = Convert.ToInt32( reader["State_Id"]);
                        TblUserRegistrations.CityId = Convert.ToInt32( reader["City_Id"]);
                        
                    }
                    
                }
            }
            return TblUserRegistrations;
        }
    }
}
