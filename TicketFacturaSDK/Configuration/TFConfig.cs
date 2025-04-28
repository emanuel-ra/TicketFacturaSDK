namespace TicketFacturaSDK.Configuration
{
    public class TFConfig
    {
        public string BaseUrl { get; set; }
        public string Dominio { get; set; }
        public string KeyTimbrado { get; set; }
        public string Version { get; set; } = "1.0";
        public string Programa { get; set; } = "Externo";
        public string Tipo { get; set; } = "Tickes";
    }
}
