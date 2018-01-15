using System.Collections.Generic;

namespace DotNetCoreReactShop.ViewModels
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public List<string> PizzaNos { get; set; }
    }
}
