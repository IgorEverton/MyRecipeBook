using AutoMapper;
using MyRecipeBook.Communication.Request;

namespace MyRecipeBook.Application.Service.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping() 
    {
            
    }   
    
    private void RequestToDomain()
    {
        CreateMap<RequestRegisterUserJson, Domain.Entities.User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
    }
}
