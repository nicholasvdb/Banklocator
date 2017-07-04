using AutoMapper;
using BankLocator.Api.Models;
using BankLocator.Api.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankLocator.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, Bankoffice>()
                .ForMember(c => c.Company, option => option.Ignore())
                .ForMember(c => c.BankofficeID, option => option.Ignore());
        }
    }
}
