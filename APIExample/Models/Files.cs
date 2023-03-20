namespace APIScan.Models
{
    public class Files
    {
        public int IdFile { get; set; }
        public int IdUserScanner { get; set; }
        public int IdPerfil { get; set; }
        public int IdFarmacia { get; set; }
        public string URL { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaSubida { get; set; }
    }
}
