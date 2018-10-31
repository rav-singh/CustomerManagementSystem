using AutoMapper;
using CustomerManagementSys;
using CustomerManagementSys.Dtos;
using CustomerManagementSys.Models;
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
            Mapper.CreateMap<Service, ServiceDto>();
            Mapper.CreateMap<ServiceDto, Service>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<ServiceDto, Service>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}