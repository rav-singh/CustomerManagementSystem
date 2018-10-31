using CustomerManagementSys.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CustomerManagementSys.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public Customer RelatedCustomer { get; set; }
        public DateTime BeginService { get; set; }
        public DateTime EndService { get; set; }
    }
}
