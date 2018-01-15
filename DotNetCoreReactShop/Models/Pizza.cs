using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreReactShop.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }

        [StringLength(6,MinimumLength = 6)]
        [RegularExpression(@"^[0-9]{6}$")]
        public string PizzaNo { get; set; }
        public string PizzaName { get; set; }

        public decimal Price { get; set; }
        public string Image { get; set; }

        public virtual string CategoryName { get; set; }
        public virtual Category Category { get; set; }

    }
}
