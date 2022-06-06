using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services.Communication;

public class ModelToResourceProfile:AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Cooperative, CooperativeResponse>();
        CreateMap<Date, DateResponse>();
        CreateMap<Design, DesignResponse>();
        CreateMap<Information, InformationResponse>();
        CreateMap<Plan, PlanResponse>();
        CreateMap<Post, PostResponse>();
        CreateMap<Profile, ProfileResponse>();
        CreateMap<User, UserResponse>();
        CreateMap<UserType, UserTypeResponse>();
    }
}