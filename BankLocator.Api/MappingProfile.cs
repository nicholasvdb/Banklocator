using AutoMapper;
using BankLocator.Api.Models;
using BankLocator.Api.Tasks;

namespace BankLocator.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, Bankoffice>()
                .ForMember(c => c.Company, option => option.Ignore())
                .ForMember(c => c.BankofficeID, option => option.Ignore());

            CreateMap<Agence, Bankoffice>()
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.Nom))
                .ForMember(c => c.Company, option => option.Ignore())
                .ForMember(c => c.BankofficeID, option => option.Ignore());
        }
    }
}
