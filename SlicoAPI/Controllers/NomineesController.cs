using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SlicoAPI.Models;
using System.Data.SqlClient;

namespace SlicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomineesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NomineesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpGet]
        public JsonResult Get()
        {

            string query = @"Select * from Nominee";

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

        [HttpGet]
        public JsonResult Get(int id)
        {

            string query = @"Select * from Nominee where NomineeID = " +id +" ";

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
        public JsonResult Post(Nominees nominees )

        {

            //string query = @"Insert into Customer values ('" + customers.IDCode + "', '" + customers.Firstname + "','" + customers.MiddleName + "','" + customers.LastName + "', '" + customers.Gender + "','" + customers.DOB + "','" + customers.BusinessLocation + "','" + customers.Address + "','" + customers.Region + "','" + customers.District + "','" + customers.Telephone + "','" + customers.RegDate + "','" + customers.Photo + "','" + customers.Username + "' ";
            string query = @"Insert into Nominee values (@FFID,@NomineeStatus, @FirstName,@MiddleName,@Lastname,@Gender,@DOB,@Address,@Telephone,@Relationship, @PercentageShared,@RegDate)";

            DataTable table = new DataTable();

            string SqlDataSource = _configuration.GetConnectionString("conn");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(SqlDataSource))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FFID", nominees.FFID);
                    command.Parameters.AddWithValue("@FirstName", nominees.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", nominees.MiddleName);
                    command.Parameters.AddWithValue("@LastName", nominees.LastName);
                    command.Parameters.AddWithValue("@Gender", nominees.Gender);
                    command.Parameters.AddWithValue("@Telephone", nominees.Telephone);
                    command.Parameters.AddWithValue("@Address", nominees.Address);
                    command.Parameters.AddWithValue("@RegDate", nominees.RegDate);
                    command.Parameters.AddWithValue("@NomineeStatus", nominees.NomineeStatus);
                    command.Parameters.AddWithValue("@Relationship", nominees.Relationship);
                    command.Parameters.AddWithValue("@PercentageShared", nominees.PercentageShared);
                    command.Parameters.AddWithValue("@DOB", nominees.DOB);
                   

                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(int id, Nominees nominees )

        {

            //string query = @"Insert into Customer values ('" + customers.IDCode + "', '" + customers.Firstname + "','" + customers.MiddleName + "','" + customers.LastName + "', '" + customers.Gender + "','" + customers.DOB + "','" + customers.BusinessLocation + "','" + customers.Address + "','" + customers.Region + "','" + customers.District + "','" + customers.Telephone + "','" + customers.RegDate + "','" + customers.Photo + "','" + customers.Username + "' ";
            string query = @"Update Nominee set FFID=@FFID,NomineeStatus=@NomineeStatus,FirstName= @FirstName,MiddleName =@MiddleName,LastName=@LastName,Gender= @Gender,DOB=@DOB,Relationship=@Relationship, PercentageShared=@PercentageShared, Address=@Address,Telephone=@Telephone,RegDate=@RegDate where NomineeID = " + id + " ";

            DataTable table = new DataTable();

            string SqlDataSource = _configuration.GetConnectionString("conn");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(SqlDataSource))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FFID", nominees.FFID);
                    command.Parameters.AddWithValue("@FirstName", nominees.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", nominees.MiddleName);
                    command.Parameters.AddWithValue("@LastName", nominees.LastName);
                    command.Parameters.AddWithValue("@Gender", nominees.Gender);
                    command.Parameters.AddWithValue("@Telephone", nominees.Telephone);
                    command.Parameters.AddWithValue("@Address", nominees.Address);
                    command.Parameters.AddWithValue("@RegDate", nominees.RegDate);
                    command.Parameters.AddWithValue("@NomineeStatus", nominees.NomineeStatus);
                    command.Parameters.AddWithValue("@Relationship", nominees.Relationship);
                    command.Parameters.AddWithValue("@PercentageShared", nominees.PercentageShared);
                    command.Parameters.AddWithValue("@DOB", nominees.DOB);


                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id, Nominees nominees )

        {

            //string query = @"Insert into Customer values ('" + customers.IDCode + "', '" + customers.Firstname + "','" + customers.MiddleName + "','" + customers.LastName + "', '" + customers.Gender + "','" + customers.DOB + "','" + customers.BusinessLocation + "','" + customers.Address + "','" + customers.Region + "','" + customers.District + "','" + customers.Telephone + "','" + customers.RegDate + "','" + customers.Photo + "','" + customers.Username + "' ";
            string query = @" delete from Nominee where NomineeID = " + id + " ";
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
