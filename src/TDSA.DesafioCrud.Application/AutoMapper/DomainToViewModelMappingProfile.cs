using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSA.DesafioCrud.Application.ViewModels;
using TDSA.DesafioCrud.Domain.Models;

namespace TDSA.DesafioCrud.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
