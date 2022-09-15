namespace FirstProject.Dtos
{
    public class UpdateRestaurantMenuDto
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string MealName { get; set; }
        public decimal PriceInNis { get; set; }
        public decimal PriceInUsd { get; set; }
        public int Quantity { get; set; }
    }
}
