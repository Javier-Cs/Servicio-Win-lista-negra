namespace WorkerService1.Modelos
{
    public class CredencialesCorreos
    {
        public int Credecod { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string pass_encryp { get; set; }
        public string host { get; set; }
        public int puerto { get; set; }
        public bool usassl { get; set; }
        public bool estado { get; set; }
        public string proveedor { get; set; }

        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public DateTime? token_expira { get; set; }

        public int intervaloMinutos { get; set; }
        public DateTime? ultimoChequeo { get; set; }
    }
}
