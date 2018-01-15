
namespace DotNetCoreReactShop.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public string Pizza { get; set; }
        //public string Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        public virtual int OrderId { get; set; }
        //public virtual Order Order { get; set; }

    }
}
