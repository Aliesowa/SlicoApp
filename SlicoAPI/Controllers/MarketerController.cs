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
    public class MarketerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MarketerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpGet]
        public JsonResult Get()
        {

            string query = @"Select * from Marketer";

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

            string query = @"Select * from Marketer where MarketerID = " +id +" ";

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
        public JsonResult Post(Marketer marketer )

        {

             string query = @"Insert into Marketer values (@MarketerID,@FirstName,@MiddleName,@LastName,@gender,@Telephone, @Address,@RegDate,@username)";

            DataTable table = new DataTable();

            string SqlDataSource = _configuration.GetConnectionString("conn");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(SqlDataSource))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@MarketerID", marketer.MarketerID);
                    command.Parameters.AddWithValue("@FirstName", marketer.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", marketer.MiddleName);
                    command.Parameters.AddWithValue("@LastName", marketer.LastName);
                    command.Parameters.AddWithValue("@gender", marketer.Gender);
                    command.Parameters.AddWithValue("@Telephone", marketer.Telephone);
                    command.Parameters.AddWithValue("@Address", marketer.Address);
                    command.Parameters.AddWithValue("@RegDate", marketer.RegDate);
                    command.Parameters.AddWithValue("@username", marketer.RegDate);
                    
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(int id, Marketer marketer )

        {
            string query = @"Update Marketer set FirstName= @FirstName,MiddleName =@MiddleName,LastName=@LastName,Gender= @Gender, Address=@Address,Telephone=@Telephone,Username= @username,RegDate=@RegDate where MarketerID = " + id + " ";

            DataTable table = new DataTable();

            string SqlDataSource = _configuration.GetConnectionString("conn");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(SqlDataSource))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@MarketerID", marketer.MarketerID);
                    command.Parameters.AddWithValue("@FirstName", marketer.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", marketer.MiddleName);
                    command.Parameters.AddWithValue("@LastName", marketer.LastName);
                    command.Parameters.AddWithValue("@gender", marketer.Gender);
                    command.Parameters.AddWithValue("@Telephone", marketer.Telephone);
                    command.Parameters.AddWithValue("@Address", marketer.Address);
                    command.Parameters.AddWithValue("@RegDate", marketer.RegDate);
                    command.Parameters.AddWithValue("@username", marketer.RegDate);


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

            string query = @"delete from marketer where Markerter = " + id + " ";
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
