using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Restaurantmenus = new HashSet<Restaurantmenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<Restaurantmenu> Restaurantmenus { get; set; }
    }
}
