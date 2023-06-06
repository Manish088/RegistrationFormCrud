using CrudOperation1.Models;
using CrudOperation1.Repositories.Contract;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CrudOperation1.Repositories.Implementation
{
    public class CityRepository : IGenericCityRepository<tblCity>
    {
        private readonly IConfiguration _configuration;
        public CityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<tblCity>> GetCityList(int StateId)
        {
            List<tblCity> cityLists = new List<tblCity>();
            using (var connetion = new SqlConnection(_configuration.GetConnectionString("CrudOperationMegaminds")))
            {
                connetion.Open();
                SqlCommand cmd = new SqlCommand("Sp_ListtblCity", connetion);
               
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = StateId;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        cityLists.Add(new tblCity
                        {
                            CityId = Convert.ToInt32(dr["id"]),
                            CityName = dr["City_Name"].ToString()
                        });
                    }
                }
            }
            return cityLists;
        }
    }
}
