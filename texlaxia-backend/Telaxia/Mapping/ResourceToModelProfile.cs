using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Resources;
using Profile = AutoMapper.Profile;

namespace texlaxia_backend.Telaxia.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCommentResource, Comment>();
        CreateMap<SaveDesignCollaboratorResource, DesignCollaborator>();
        CreateMap<SavePostResource, PostDesign>();
        CreateMap<SavePostResource, Post>();
        CreateMap<SavePurchaseResource, Purchase>();
        CreateMap<SaveUserResource, User>();
        CreateMap<SavePlanResource, Plan>();
        CreateMap<SaveBuyerResource, Buyer>();
        CreateMap<SaveDesignerResource, Designer>();
    }
}