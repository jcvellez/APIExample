using System.ComponentModel.DataAnnotations;

namespace APIScan.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }        
        public string Mail { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }       
        public string UserName { get; set; }
        public string Dni { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public DateTime FechaNacimiento { get; set; }     
        public int Rol { get; set; }
    }
}
