using System;

namespace CustomerManagementSys.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerDto RelatedCustomer { get; set; }
        public DateTime BeginService { get; set; }
        public DateTime EndService { get; set; }
    }
}