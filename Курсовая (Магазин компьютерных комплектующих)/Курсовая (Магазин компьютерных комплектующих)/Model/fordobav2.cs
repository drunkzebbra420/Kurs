using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model
{
    public partial class Basket
    {
        public string Images { get { return PhotoProduct !=  null ? $@"C:\Users\Emil\source\repos\Курсовая (Магазин компьютерных комплектующих)\Курсовая (Магазин компьютерных комплектующих)\image\productPhoto\{PhotoProduct}" : null; } }


    }
}
