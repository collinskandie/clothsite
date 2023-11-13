namespace clothStore.Models
{
    public class Cloth
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double Ratings { get; set; }
        public string? ImageUrl { get; set; }
    }
}
