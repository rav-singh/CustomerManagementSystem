using AutoMapper;
using CustomerManagementSys.Dtos;
using CustomerManagementSys.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpendCheck.Controllers.Api
{
    public class ServicesController : ApiController
    {
        private ApplicationDbContext _context;

        public ServicesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetServices(string query = null)
        {
            var servicesQuery = _context.Services.Include(c => c.RelatedCustomer.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                servicesQuery = servicesQuery.Where(m => m.Name.Contains(query));

            var servicesDtos = servicesQuery
                .ToList()
                .Select(Mapper.Map<Service, ServiceDto>);

            return Ok(servicesDtos);
        }

        public IHttpActionResult GetService(int id)
        {
            var service = _context.Services.SingleOrDefault(c => c.Id == id);

            if (service == null)
                return NotFound();

            return Ok(Mapper.Map<Service, ServiceDto>(service));
        }

        [HttpPost]
        public IHttpActionResult CreateNewService(NewServiceDto newService)
        {
            // Grab Customer 
            var customer = _context.Customers.Include(c => c.MembershipType).Single(
                c => c.Id == newService.CustomerId);

            if (customer == null)
                return BadRequest("Invalid Customer");

            // New Service 
            var service = new Service
            {
                RelatedCustomer = customer,
                Name = newService.Name,
                BeginService = DateTime.Now,

                // Calculate End Service Dynamically based on customer membership plan 
                EndService = DateTime.Now.AddMonths(customer.MembershipType.DurationInMonths)
            };

            _context.Services.Add(service);
            _context.SaveChanges();

            return Ok();
        }
    }
}
