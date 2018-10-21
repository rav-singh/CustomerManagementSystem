using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace CustomerManagementSys.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        private ApplicationDbContext _context;

        public Customer()
        {
            _context = new ApplicationDbContext();
        }

        public Customer(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool SaveCustomer(Customer customer)
        {

            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            if (_context.SaveChanges() > 0)
                return true;

            return false;
        }

        public List<Customer> GetAllCustomersWithMembership()
        {
            List<Customer> returnLst = _context.Customers.Include(c => c.MembershipType).ToList();
            return returnLst;
        }

        public Customer GetCustomerWithMembership(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return customer;
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            return customer;
        }


    }
}