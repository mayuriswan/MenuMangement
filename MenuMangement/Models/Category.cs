namespace MenuMangement.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MenuId { get; set; }  // Foreign key to Menu

        public Menu? Menu { get; set; }  // Navigation property
        public List<MenuItem>? MenuItems { get; set; } = new List<MenuItem>();
    }

}
