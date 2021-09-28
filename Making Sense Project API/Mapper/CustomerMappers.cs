using AutoMapper;
using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Mapper
{
    public class CustomerMappers : Profile
    {
        public CustomerMappers()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
