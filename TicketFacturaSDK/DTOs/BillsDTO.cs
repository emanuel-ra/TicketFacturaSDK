using System.Collections.Generic;

namespace TicketFacturaSDK.DTOs
{
    public class BillsDTO
    {
        public class ResponseDTO
        {
            public int StatusCode { get; set; }
            public string Response { get; set; }
            public List<Bill> Bills { get; set; }
        }
        public class Bill
        {
            public int? Folio { get; set; }
            public string XML { get; set; }
            public bool Vigente { get; set; }
            public string UUIDFiscal { get; set; }
        }
        public class RequestBIllDTO : RequestDTO
        {
            public int NumberTicket { get; set; }
        }
    }
}
