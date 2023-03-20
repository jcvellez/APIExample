using APIScan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace APIScan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : Controller
    {
        private readonly IConfiguration _configuration;
        public NotificacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select 
                    IdNotificacion as ""IdNotificacion"",
                    Uid as ""Uid"",
                    NotId as ""NotId""
                from Notificacion
            ";

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Notificacion not)
        {
            string query = @"
                insert into Notificacion(Uid,NotId)
                values(@Uid, @NotId)
            "
            ;

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Uid", not.Uid);
                    myCommand.Parameters.AddWithValue("@NotId", not.NotId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Ok Add");
        }

        [HttpPut]
        public JsonResult Put(Notificacion not)
        {
            string query = @"
                update Notificacion set 
                        Uid = @Uid,
                        NotId = @NotId                                              
                where IdNotificacion = @IdNotificacion                     
            ";

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Uid", not.Uid);
                    myCommand.Parameters.AddWithValue("@NotId", not.NotId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Ok Update");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from Notificacion where IdNotificacion=@IdNotificacion
            "
            ;

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdNotificacion", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Ok Del");
        }

    }
}
