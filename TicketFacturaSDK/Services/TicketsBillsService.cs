using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TicketFacturaSDK.Configuration;
using TicketFacturaSDK.DTOs;

namespace TicketFacturaSDK.Services
{
    public class TicketsBillsService
    {
        private readonly HttpClient _httpClient;
        private readonly TFConfig _config;
        private const string Endpoint = "TicketsBills";

        public TicketsBillsService(HttpClient httpClient, TFConfig config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<TicketsDTO.ResponseDTO> GetTicketsBillsAsync(TicketsDTO.RequestFiltersDTO request)
        {
            request.Dominio = _config.Dominio;
            request.KeyTimbrado = _config.KeyTimbrado;
            request.Version = _config.Version;
            request.Programa = _config.Programa;
            request.Tipo = _config.Tipo;

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{Endpoint}", request);

            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return new JavaScriptSerializer().Deserialize<TicketsDTO.ResponseDTO>(responseContent);
            }
            else
            {
                return new TicketsDTO.ResponseDTO
                {
                    StatusCode = (int)response.StatusCode,
                    Response = responseContent,
                    FoliosSussed = null
                };
            }

        }
    }
}
