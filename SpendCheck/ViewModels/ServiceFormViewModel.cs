using CustomerManagementSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementSys.ViewModels
{
    public class ServiceFormViewModel
    {

        public byte Id { get; set; }
        public string Name { get; set; }
        public Customer RelatedCustomer { get; set; }
        public DateTime? BeginService { get; set; }
        public DateTime? EndService { get; set; }

    }
}