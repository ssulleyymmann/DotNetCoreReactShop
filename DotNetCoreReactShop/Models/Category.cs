using System.Collections.Generic;

namespace DotNetCoreReactShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
