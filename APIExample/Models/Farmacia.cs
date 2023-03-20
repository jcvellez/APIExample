namespace APIScan.Models
{
    public class Farmacia
    {
        public int IdFarmacia { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
        public string RUC { get; set; }
        public bool Habilitado { get; set; }
    }
}
