
using Application.Activities.Requests;
using AutoMapper;
using Domain;

namespace Application.Core.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, Activity>();
        CreateMap<CreateActivityRequest, Activity>();
    }
}
