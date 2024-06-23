using Amega.Service.DTO.ExternalApi;
using Amega.Service.Query;
using Amega.Service.Services.ExternalApi.Models;


namespace Amega.Service.IServicies.ExternalApi
{
    public interface ITradeService
    {
        Task<List<ForexInstrumentDto>> GetAvailableInstumentsAsync(GetInstruments query);
        Task<List<ForexInstrumentPriceDto>> GetInstrumentPricesAsync(GetInstrumentPrices query);
    }
}
