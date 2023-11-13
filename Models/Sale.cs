namespace clothStore.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ClothId { get; set; }
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }
        
    }
}
