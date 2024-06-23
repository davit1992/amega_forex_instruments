using Amega.Service.IServicies.ExternalApi;
using Amega.Service.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amega.Api.Controllers
{
    [Route("integration")]
    [ApiController]
    public class IntegrationController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        public IntegrationController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }
        [HttpGet("instuments")]
        public async Task<IActionResult> GetInstuments([FromQuery] GetInstruments query)
        {
            var data = await _tradeService.GetAvailableInstumentsAsync(query);
            return Ok(data);
        }
        [HttpGet("instuments/pricies")]
        public async Task<IActionResult> GetInstumentPrices([FromQuery] GetInstrumentPrices query)
        {
            var data = await _tradeService.GetInstrumentPricesAsync(query);
            return Ok(data);
        }
    }
}
