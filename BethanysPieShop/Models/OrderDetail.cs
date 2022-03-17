using System.ComponentModel.DataAnnotations.Schema;

namespace BethanysPieShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("PieId")]
        public Pie Pie { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}