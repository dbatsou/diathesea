using AutoMapper;
using Domain.Entities;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<State, State>();
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityEntry>();
        }
    }
}