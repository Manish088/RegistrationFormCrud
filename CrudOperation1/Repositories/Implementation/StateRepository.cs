using CrudOperation1.Models;
using CrudOperation1.Repositories.Contract;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CrudOperation1.Repositories.Implementation
{
    public class StateRepository : IGenericStateRepository<tblState>
    {
        private readonly IConfiguration _configuration;
        public StateRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<tblState>> GetStateList()
        {
            List<tblState> stateLists = new List<tblState>();
            using (var connetion = new SqlConnection(_configuration.GetConnectionString("CrudOperationMegaminds")))
            {
                connetion.Open();
                SqlCommand cmd = new SqlCommand("Sp_ListtblState", connetion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        stateLists.Add(new tblState
                        {
                            StateId =Convert.ToInt32( dr["Id"]),
                            StateName = dr["State_Name"].ToString()
                        });
                    }
                }
            }
            return stateLists;
        }
    }
}
