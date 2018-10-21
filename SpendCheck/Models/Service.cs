using CustomerManagementSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementSys
{
    public class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Customer RelatedCustomer { get; set; }
        public MembershipType RelatedCustMembership { get; set; }
        public string WebSiteName { get; set; }
    }
}
