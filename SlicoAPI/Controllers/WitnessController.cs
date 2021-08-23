using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SlicoAPI.Models;
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
    public class WitnessController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public WitnessController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpGet]
        public JsonResult Get()
        {

            string query = @"Select * from Witness";

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


        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {

            string query = @"Select * from Witness where WittnessID = "+ id+ " ";

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

        [HttpPost]
        public JsonResult Post(Witness witness)

        {

            //string query = @"Insert into Customer values ('" + customers.IDCode + "', '" + customers.Firstname + "','" + customers.MiddleName + "','" + customers.LastName + "', '" + customers.Gender + "','" + customers.DOB + "','" + customers.BusinessLocation + "','" + customers.Address + "','" + customers.Region + "','" + customers.District + "','" + customers.Telephone + "','" + customers.RegDate + "','" + customers.Photo + "','" + customers.Username + "' ";
            //string query = @"Insert into Witness values (" + witness.FFID + "," + witness.FirstName + "," + witness.MiddleName + "," + witness.LastName + ", " + witness.Gender + "," + witness.Telephone + "," + witness.Address + "," + witness.RegDate + " ";
            string query = @"Insert into Witness values (@FFID,@FirstName,@MiddleName,@LastName,@gender,@Telephone,@Address,@RegDate)";

            DataTable table = new DataTable();

            string SqlDataSource = _configuration.GetConnectionString("conn");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(SqlDataSource))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@FFID", witness.FFID);
                    command.Parameters.AddWithValue("@FirstName", witness.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", witness.MiddleName);
                    command.Parameters.AddWithValue("@LastName", witness.LastName);
                    command.Parameters.AddWithValue("@gender", witness.Gender);
                    command.Parameters.AddWithValue("@Telephone", witness.Telephone);
                    command.Parameters.AddWithValue("@Address", witness.Address);
                    command.Parameters.AddWithValue("@RegDate", witness.RegDate);
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(int id, Witness witness)

        {
              string query = @"Update Witness set FFID=@FFID,FirstName= @FirstName,MiddleName =@MiddleName,LastName=@LastName,Gender= @Gender, Address=@Address,Telephone=@Telephone,RegDate=@RegDate where WittnessID = " + id + " ";

            DataTable table = new DataTable();

            string SqlDataSource = _configuration.GetConnectionString("conn");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(SqlDataSource))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@FFID", witness.FFID);
                    command.Parameters.AddWithValue("@FirstName", witness.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", witness.MiddleName);
                    command.Parameters.AddWithValue("@LastName", witness.LastName);
                    command.Parameters.AddWithValue("@gender", witness.Gender);
                    command.Parameters.AddWithValue("@Telephone", witness.Telephone);
                    command.Parameters.AddWithValue("@Address", witness.Address);
                    command.Parameters.AddWithValue("@RegDate", witness.RegDate);


                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)

        {

             string query = @"delete from Witness where WittnessID = " + id + " ";
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
            return new JsonResult("Deleted successfully");
        }

    

}
}
