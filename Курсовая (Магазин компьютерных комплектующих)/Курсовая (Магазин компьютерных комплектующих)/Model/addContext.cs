using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model
{
    public partial class addContext : App
    {
        public static ShopcoumpcomplectContext Context { get; } = new ShopcoumpcomplectContext();
        public static int idUser { get; set; }
        public static string FullName { get; set; }
        public static int Role { get; set; }

        public static List<Basket> baskets = new List<Basket>();

    }

    public partial class Basket
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public decimal? CostProduct { get; set; }

        public string PhotoProduct { get; set; }
        public int Count { get; set; }

    }
}
