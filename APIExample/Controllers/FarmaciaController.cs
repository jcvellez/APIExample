using APIScan.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace APIScan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public FarmaciaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
             select IdFarmacia as ""IdFarmacia"",
                    Nombre as ""Nombre"",
                    RazonSocial as ""RazonSocial"",
                    Telefono1 as ""Telefono1"",
                    Telefono2 as ""Telefono2"",
                    Direccion as ""Direccion"",
                    RUC as ""RUC"",
                    Habilitado as ""Habilitado""                    
                from Farmacia
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
        public JsonResult Post(Farmacia far)
        {
            string query = @"
                insert into Farmacia(
                    Nombre, RazonSocial, Telefono1, Telefono2, Direccion, RUC, Habilitado)
                values(@Nombre, @RazonSocial, @Telefono1, @Telefono2, @Direccion, @RUC, @Habilitado)
            ";

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Nombre", far.Nombre);
                    myCommand.Parameters.AddWithValue("@RazonSocial", far.RazonSocial);
                    myCommand.Parameters.AddWithValue("@Telefono1", far.Telefono1);
                    myCommand.Parameters.AddWithValue("@Telefono2", far.Telefono2);
                    myCommand.Parameters.AddWithValue("@Direccion", far.Direccion);
                    myCommand.Parameters.AddWithValue("@RUC", far.RUC);
                    myCommand.Parameters.AddWithValue("@Habilitado", far.Habilitado);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Ok Add");
        }

        [HttpPut]
        public JsonResult Put(Farmacia far)
        {
            string query = @"
                update Farmacia set 
                        Nombre = @Nombre,
                        RazonSocial = @RazonSocial,
                        Telefono1 = @Telefono1,
                        Telefono2 = @Telefono2,
                        Direccion = @Direccion,
                        RUC = @RUC,
                        Habilitado = @Habilitado                        
                where IdFarmacia = @IdFarmacia                
            ";

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Nombre", far.Nombre);
                    myCommand.Parameters.AddWithValue("@RazonSocial", far.RazonSocial);
                    myCommand.Parameters.AddWithValue("@Telefono1", far.Telefono1);
                    myCommand.Parameters.AddWithValue("@Telefono2", far.Telefono2);
                    myCommand.Parameters.AddWithValue("@Direccion", far.Direccion);
                    myCommand.Parameters.AddWithValue("@RUC", far.RUC);
                    myCommand.Parameters.AddWithValue("@Habilitado", far.Habilitado);
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
                delete from Farmacia where IdFarmacia=@IdFarmacia
            ";

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdFarmacia", id);
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
