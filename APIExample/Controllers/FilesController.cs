using APIScan.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace APIScan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public FilesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
             select IdFile as ""IdFile"",
                    IdUserScanner as ""IdUserScanner"",
                    IdPerfil as ""IdPerfil"",
                    IdFarmacia as ""IdFarmacia"",
                    URL as ""URL"",
                    Usuario as ""Usuario"",
                    Nombre as ""Nombre"",
                    Tipo as ""Tipo"",
                    Estado as ""Estado"",
                    FechaSubida as ""FechaSubida""
                from Files
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
        public JsonResult Post(Files fil)
        {
            string query = @"
                insert into Files(
                    IdUserScanner, IdPerfil, IdFarmacia, URL, Usuario, Nombre, Tipo, Estado, FechaSubida)
                values(@IdUserScanner, @IdPerfil, @IdFarmacia, @URL, @Usuario, @Nombre, @Tipo, @Estado, @FechaSubida)
            ";

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdUserScanner", fil.IdUserScanner);
                    myCommand.Parameters.AddWithValue("@IdPerfil", fil.IdPerfil);
                    myCommand.Parameters.AddWithValue("@IdFarmacia", fil.IdFarmacia);
                    myCommand.Parameters.AddWithValue("@URL", fil.URL);
                    myCommand.Parameters.AddWithValue("@Usuario", fil.Usuario);
                    myCommand.Parameters.AddWithValue("@Nombre", fil.Nombre);
                    myCommand.Parameters.AddWithValue("@Tipo", fil.Tipo);
                    myCommand.Parameters.AddWithValue("@Estado", fil.Estado);
                    myCommand.Parameters.AddWithValue("@FechaSubida", fil.FechaSubida);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Ok Add");
        }

        [HttpPut]
        public JsonResult Put(Files fil)
        {
            string query = @"
                update Files set 
                        IdUserScanner = @IdUserScanner,
                        IdPerfil = @IdPerfil,
                        IdFarmacia = @IdFarmacia,
                        URL = @URL,
                        Usuario = @Usuario,
                        Nombre = @Nombre,
                        Tipo = @Tipo,                        
                        Estado = @Estado,                        
                        FechaSubida = @FechaSubida                        
                where IdFile = @IdFile                
            ";

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdUserScanner", fil.IdUserScanner);
                    myCommand.Parameters.AddWithValue("@IdPerfil", fil.IdPerfil);
                    myCommand.Parameters.AddWithValue("@IdFarmacia", fil.IdFarmacia);
                    myCommand.Parameters.AddWithValue("@URL", fil.URL);
                    myCommand.Parameters.AddWithValue("@Usuario", fil.Usuario);
                    myCommand.Parameters.AddWithValue("@Nombre", fil.Nombre);
                    myCommand.Parameters.AddWithValue("@Tipo", fil.Tipo);
                    myCommand.Parameters.AddWithValue("@Estado", fil.Estado);
                    myCommand.Parameters.AddWithValue("@FechaSubida", fil.FechaSubida);
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
                delete from Files where IdFile=@IdFile
            ";

            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdFile", id);
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
