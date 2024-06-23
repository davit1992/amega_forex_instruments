using Amega.Service.DTO.ExternalApi;
using Amega.Service.Services.ExternalApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amega.Service.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<AggTradeData, TradeDto>()
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.e))
                .ForMember(dest => dest.EventTime, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeMilliseconds(src.E).UtcDateTime))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.s))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.a))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.p))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.q))
                .ForMember(dest => dest.FirstId, opt => opt.MapFrom(src => src.f))
                .ForMember(dest => dest.LastId, opt => opt.MapFrom(src => src.l))
                .ForMember(dest => dest.TradeTime, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeMilliseconds(src.T).UtcDateTime))
                .ForMember(dest => dest.IsMarketMakerBuyer, opt => opt.MapFrom(src => src.m))
                .ForMember(dest => dest.Ignore, opt => opt.MapFrom(src => src.M));

            CreateMap<ForexInstrument, ForexInstrumentDto>();
            CreateMap<ForexInstrumentPrice, ForexInstrumentPriceDto>();
        }
    }
}
