using AutoMapper;
using Domain.Entities;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<State, State>();
            CreateMap<StateEntry, StateEntry>();
        }
    }
}