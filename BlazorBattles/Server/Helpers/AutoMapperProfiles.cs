using AutoMapper;
using BlazorBattles.Server.Entities;
using BlazorBattles.Shared.DTOs;

namespace BlazorBattles.Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<UnitDto, Unit>();
        }
    }
}
