using System.Collections.Generic;

namespace DotNetCoreReactShop.ViewModels
{
    public class PizzaVM
    {
        public string PizzaNo { get; set; }
        public string PizzaName { get; set; }
        public decimal Price{ get; set; }
        public virtual string CategoryName { get; set; }
        public string Image { get; set; }
        public List<string> Sizes { get; set; }
        public List<int> Quantities { get; set; }

    }
}
