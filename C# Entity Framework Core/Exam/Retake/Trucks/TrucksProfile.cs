using Trucks.Data.Models;
using Trucks.DataProcessor.ExportDto;

namespace Trucks
{
    using AutoMapper;

    public class TrucksProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TrucksProfile()
        {
            CreateMap<Truck, ExportTruckForDispatcherDto>()
                .ForMember(d => d.Make, mo => mo.MapFrom(s => s.MakeType.ToString()));

            CreateMap<Despatcher, ExportDespatcherDto>()
                .ForMember(d => d.TrucksCount, mo => mo.MapFrom(s => s.Trucks.Count));

        }
    }
}
