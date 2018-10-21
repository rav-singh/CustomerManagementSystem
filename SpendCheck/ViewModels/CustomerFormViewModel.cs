using CustomerManagementSys.Models;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagementSys.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}