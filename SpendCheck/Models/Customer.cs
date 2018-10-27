using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;

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

        //private ApplicationDbContext _context;

        //public Customer()
        //{
        //    _context = new ApplicationDbContext();
        //}

        //public Customer(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //public List<Customer> GetAllCustomersWithMembership()
        //{
        //    List<Customer> returnLst = _context.Customers.Include(c => c.MembershipType).ToList();
        //    return returnLst;
        //}

        //public Customer GetCustomerWithMembership(int id)
        //{
        //    var customerInDb = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

        //    if (customerInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return customerInDb;
        //}

        //public Customer GetCustomer(int id)
        //{
        //    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        //    return customerInDb;
        //}

        //public void UpdateCustomer(Customer customerInDb, Customer cust)
        //{

        //    customerInDb.Name = cust.Name;
        //    customerInDb.Birthdate = cust.Birthdate;
        //    customerInDb.MembershipTypeId = cust.MembershipTypeId;
        //    customerInDb.IsSubscribedToNewsletter = cust.IsSubscribedToNewsletter;

        //    _context.SaveChanges();
        //}

        //public void SaveCustomer(Customer customer)
        //{

        //    if (customer.Id == 0)
        //        _context.Customers.Add(customer);

        //    else
        //    {
        //        var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
        //        UpdateCustomer(customerInDb, customer);
        //    }

        //    _context.SaveChanges();
        //}

        //public void DeleteCustomer(Customer customerInDb)
        //{
        //    _context.Customers.Remove(customerInDb);
        //    _context.SaveChanges();

        //}
    }
}