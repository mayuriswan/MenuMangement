namespace MenuMangement.API.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RestaurantId { get; set; }  // Foreign key to Restaurant
        public Restaurant Restaurant { get; set; }  // Navigation property
        public List<Category> Categories { get; set; } = new List<Category>();
    }

}
