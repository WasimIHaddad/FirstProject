using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Archived { get; set; }
    }
}
