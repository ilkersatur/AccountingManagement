using Accounting.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Accounting.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Accounting.Domain.AppEntities;
using Accounting.Domain.CompanyEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyRequest, Company>().ReverseMap();
            CreateMap<CreateUCAFRequest, UniformChartOfAccount>().ReverseMap();
        }
    }
}
