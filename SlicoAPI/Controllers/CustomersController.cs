using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SlicoAPI.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SlicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public CustomersController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }



        [HttpGet]
        public JsonResult Get()
        {

            string query = @"Select * from Customer";

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

            string query = @"Select * from Customer where IDCode = " + id + " ";

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
        public JsonResult Post(Customers customers)

        {

            //string query = @"Insert into Customer values ('" + customers.IDCode + "', '" + customers.Firstname + "','" + customers.MiddleName + "','" + customers.LastName + "', '" + customers.Gender + "','" + customers.DOB + "','" + customers.BusinessLocation + "','" + customers.Address + "','" + customers.Region + "','" + customers.District + "','" + customers.Telephone + "','" + customers.RegDate + "','" + customers.Photo + "','" + customers.Username + "' ";
            // string query = @"Insert into Customer values (@customers.IDCode + "," + customers.Firstname + "," + customers.MiddleName + "," + customers.LastName + "," + customers.Gender + "," + customers.DOB + "," + customers.BusinessLocation + "," + customers.Address + "," + customers.Region + "," + customers.District + "," + customers.Telephone + "," + customers.RegDate + "," + customers.Photo + "," + customers.Username + " ";
            string query = @"Insert into Customer values (@IDCode,@FirstName,@MiddleName,@Lastname,@Gender,@DOB,@BusinessLocation,@Address,@Region,@District,@Telephone,@RegDate,@photo , @username)";
            DataTable table = new DataTable();

            string SqlDataSource = _configuration.GetConnectionString("conn");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(SqlDataSource))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@IDCode", customers.IDCode);
                    command.Parameters.AddWithValue("@FirstName", customers.Firstname);
                    command.Parameters.AddWithValue("@MiddleName", customers.MiddleName);
                    command.Parameters.AddWithValue("@LastName", customers.LastName);
                    command.Parameters.AddWithValue("@Gender", customers.Gender);
                    command.Parameters.AddWithValue("@Telephone", customers.Telephone);
                    command.Parameters.AddWithValue("@Address", customers.Address);
                    command.Parameters.AddWithValue("@RegDate", customers.RegDate);
                    command.Parameters.AddWithValue("@photo", customers.Photo);
                    command.Parameters.AddWithValue("@BusinessLocation", customers.BusinessLocation);
                    command.Parameters.AddWithValue("@Region", customers.Region);
                    command.Parameters.AddWithValue("@District", customers.District);
                    command.Parameters.AddWithValue("@DOB", customers.DOB);
                    command.Parameters.AddWithValue("@username", customers.Username);

                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(int id, Customers customers)

        {


            string query = @"Update Customer set IDCode=@IDCode,FirstName= @FirstName,MiddleName =@MiddleName,LastName=@LastName,Gender= @Gender,DOB=@DOB,BusinessLocation=@BusinessLocation, Address=@Address, Region=@Region, District=@District,Telephone=@Telephone,RegDate=@RegDate,Photo=@photo,Username=@username where FFID = " + id + " ";


            DataTable table = new DataTable();

            string SqlDataSource = _configuration.GetConnectionString("conn");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(SqlDataSource))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDCode", customers.IDCode);
                    command.Parameters.AddWithValue("@FirstName", customers.Firstname);
                    command.Parameters.AddWithValue("@MiddleName", customers.MiddleName);
                    command.Parameters.AddWithValue("@LastName", customers.LastName);
                    command.Parameters.AddWithValue("@gender", customers.Gender);
                    command.Parameters.AddWithValue("@Telephone", customers.Telephone);
                    command.Parameters.AddWithValue("@Address", customers.Address);
                    command.Parameters.AddWithValue("@RegDate", customers.RegDate);
                    command.Parameters.AddWithValue("@photo", customers.Photo);
                    command.Parameters.AddWithValue("@BusinessLocation", customers.BusinessLocation);
                    command.Parameters.AddWithValue("@Region", customers.Region);
                    command.Parameters.AddWithValue("@District", customers.District);
                    command.Parameters.AddWithValue("@DOB", customers.DOB);
                    command.Parameters.AddWithValue("@username", customers.Username);

                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id, Customers customers)

        {

            //string query = @"Insert into Customer values ('" + customers.IDCode + "', '" + customers.Firstname + "','" + customers.MiddleName + "','" + customers.LastName + "', '" + customers.Gender + "','" + customers.DOB + "','" + customers.BusinessLocation + "','" + customers.Address + "','" + customers.Region + "','" + customers.District + "','" + customers.Telephone + "','" + customers.RegDate + "','" + customers.Photo + "','" + customers.Username + "' ";
            string query = @" delete from customer where FFID = " + id + " ";
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


        [Route("SavePhoto")]
        [HttpPost]
        public JsonResult SavePhoto([FromForm] FileUpload fileUpload)
        {
            try
            {

                if (fileUpload.files.Length > 0)
                {
                    string path = _env.WebRootPath + "\\ Photos \\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);

                    }

                    using (FileStream fileStream = System.IO.File.Create(path + fileUpload.files.FileName))
                    {
                        fileUpload.files.CopyTo(fileStream);
                        fileStream.Flush();

                    }
                }
                //var httpRequest = Request.Form;
                //var postedFile = httpRequest.Files[0];
                //string filename = postedFile.FileName;
                //var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                //using (var stream = new FileStream(physicalPath, FileMode.Create))
                //{
                //    postedFile.CopyTo(stream);
                //}

                return new JsonResult(fileUpload.files.FileName.ToString());
            }
            catch (Exception e)
            {

                return new JsonResult(e.Message.ToString());
            }
        }

      
        [HttpPost("{filename}")]
        public async Task<IActionResult> RetrievePhoto([FromRoute] string filename)
        {
            try
            {

                string path = _env.WebRootPath + "\\ Photos \\";
                var filepath = path + filename;


             if (System.IO.File.Exists(filepath))
                {
                    byte[] b = System.IO.File.ReadAllBytes(filepath);

                    return File(b, "images/~");
                 

                }

                return null;


            }
            catch (Exception e)
            {
                return new JsonResult(e.Message.ToString());
            }
        }
    }
    }
