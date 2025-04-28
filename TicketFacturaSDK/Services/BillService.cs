using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TicketFacturaSDK.Configuration;
using static TicketFacturaSDK.DTOs.BillsDTO;

namespace TicketFacturaSDK.Services
{
    public class BillService
    {
        private readonly HttpClient _httpClient;
        private readonly TFConfig _config;
        private const string Endpoint = "Bill";
        public BillService(HttpClient httpClient, TFConfig config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<ResponseDTO> GetBillAsync(int TicketNumber)
        {
            var request = new RequestBIllDTO
            {
                Dominio = _config.Dominio,
                KeyTimbrado = _config.KeyTimbrado,
                Version = _config.Version,
                Programa = _config.Programa,
                Tipo = _config.Tipo,
                NumberTicket = TicketNumber
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{Endpoint}", request);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return new JavaScriptSerializer().Deserialize<ResponseDTO>(responseContent);
            }
            else
            {
                return new ResponseDTO
                {
                    StatusCode = (int)response.StatusCode,
                    Response = responseContent,
                    Bills = null
                };
            }
        }
    }
}
