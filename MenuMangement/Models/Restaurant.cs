namespace MenuMangement.API.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public int MenuId { get; set; }  // Foreign key to Menu
        public Menu? Menu { get; set; }  // Navigation property
    }

}
