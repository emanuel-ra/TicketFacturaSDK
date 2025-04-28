using System;
using System.Collections.Generic;

namespace TicketFacturaSDK.DTOs
{
    public class TicketsDTO
    {
        public class ResponseDTO
        {
            public int StatusCode { get; set; }
            public string Response { get; set; }
            public List<FoliosSussedDTO> FoliosSussed { get; set; }
        }
        public class FoliosSussedDTO
        {
            public int NumberUnique { get; set; }
            public string Message { get; set; }
        }
        public class RequestFiltersDTO : RequestDTO
        {
            public DateTime DateInit { get; set; } = DateTime.Now.AddDays(-30);
            public DateTime DateEnd { get; set; } = DateTime.Now;
        }
    }
}
