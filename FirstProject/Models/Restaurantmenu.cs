using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Models
{
    public partial class Restaurantmenu
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string MealName { get; set; }
        public decimal PriceInNis { get; set; }
        public decimal PriceInUsd { get; set; }
        public int Quantity { get; set; }
        public bool Archived { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
   
       

        
        

        

    
}
