using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Resources;
using AutoMapper;

namespace texlaxia_backend.Telaxia.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Comment, CommentResource>();
        CreateMap<DesignCollaborator, DesignCollaboratorResource>();
        CreateMap<PostDesign, PostResource>();
        CreateMap<Post, PostResource>();
        CreateMap<Purchase, PurchaseResource>();
        CreateMap<User, UserResource>();
        CreateMap<Plan, PlanResource>();
        CreateMap<Buyer, BuyerResource>();
        CreateMap<Designer, DesignerResource>();
        CreateMap<Design, DesignResource>();
    }
}