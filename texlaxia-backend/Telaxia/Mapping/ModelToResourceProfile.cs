using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Comment, CommentResponse>();
        CreateMap<DesignCollaborator, DesignCollaboratorResponse>();
        CreateMap<PostDesign, PostDesignResponse>();
        CreateMap<Purchase, PurchaseResponse>();
        CreateMap<User, UserResponse>();
    }
}