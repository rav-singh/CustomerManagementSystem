using CustomerManagementSys.Models;
using System;


namespace CustomerManagementSys.Dtos
{
    public class NewServiceDto
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }

    }
}