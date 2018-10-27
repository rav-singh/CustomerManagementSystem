using AutoMapper;
using CustomerManagementSys.Models;
using SpendCheck.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpendCheck.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}