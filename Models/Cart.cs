namespace clothStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ClothId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }

    }
}
