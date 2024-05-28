namespace MenuMangement.API.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }  // Foreign key to Category

        public Category? Category { get; set; }  // Navigation property
    }

}
