namespace FirstProject.Dtos
{
    public class CreateRestaurantMenuDto
    {
        public int RestaurantId { get; set; }
        public string MealName { get; set; }
        public decimal PriceInNis { get; set; }
        public decimal PriceInUsd { get; set; }
        public int Quantity { get; set; }
    }
}
