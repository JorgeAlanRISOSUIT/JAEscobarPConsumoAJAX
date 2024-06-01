namespace ApiAJAX.Result
{
    public class PersonaAseguradora
    {
        public int Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string EstadoCivil { get; set; }
        public char Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Entidad Entidad { get; set; }
        public string CURP { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

    }
}
