using System;
using System.Net.Http;
using TicketFacturaSDK.Configuration;
using TicketFacturaSDK.Services;

namespace TicketFacturaSDK.Core
{
    public class TFClient
    {
        private readonly TFConfig _config;
        private readonly HttpClient _httpClient;

        public TicketsBillsService TicketsBills { get; }
        public BillService Bill { get; }
        public TFClient(TFConfig config)
        {
            if (string.IsNullOrEmpty(config.BaseUrl))
                throw new ArgumentException("BaseUrl must be set");

            _config = config;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(config.BaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();

            TicketsBills = new TicketsBillsService(_httpClient, _config);
            Bill = new BillService(_httpClient, _config);
        }
    }
}
