using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Models
{
    public partial class Customermenu
    {
        public int CustomerId { get; set; }
        public int RestaurantMenuId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Restaurantmenu RestaurantMenu { get; set; }
    }
}
