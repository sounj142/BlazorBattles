using AutoMapper;
using BlazorBattles.Server.Entities;
using BlazorBattles.Shared.DTOs;
using BlazorBattles.Shared.ViewModels;

namespace BlazorBattles.Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<UnitDto, Unit>();
            CreateMap<UserRegister, AppUser>();
            CreateMap<AppUser, UserDto>();
        }
    }
}
