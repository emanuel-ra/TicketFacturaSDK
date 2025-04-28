namespace TicketFacturaSDK.DTOs
{
    public class RequestDTO
    {
        public string Dominio { get; set; }
        public string KeyTimbrado { get; set; }
        public string Version { get; set; }
        public string Programa { get; set; }
        public string Tipo { get; set; } = "Tickes";
    }
}
