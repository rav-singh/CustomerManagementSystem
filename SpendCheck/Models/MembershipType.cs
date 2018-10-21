using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CustomerManagementSys.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

        private ApplicationDbContext _context;


        public MembershipType()
        {
            _context = new ApplicationDbContext();
        }

        public MembershipType(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MembershipType> GetAllMembershipTypes()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            return membershipTypes;
        }

    }
}