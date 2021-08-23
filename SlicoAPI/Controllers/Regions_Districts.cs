using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SlicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Regions_Districts : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Regions_Districts(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpGet]
        public JsonResult Get()
        {

            string query = @"Select * from Regions";

            DataTable table = new DataTable();

            string SqlDataSource = _configuration.GetConnectionString("conn");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(SqlDataSource))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
