using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model
{
    public partial class Product
    {
        public bool BtnOff
        {
            get
            {
                if (CountInStockProduct > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    public string Image
        {
            get
            {
                if (CountInStockProduct > 0)
                {
                    return PhotoProduct !=  null ? $@"C:\Users\Emil\source\repos\Курсовая (Магазин компьютерных комплектующих)\Курсовая (Магазин компьютерных комплектующих)\image\productPhoto\{PhotoProduct}" : null;
                    
                }
                else
                {
                    return "C:\\Users\\Emil\\source\\repos\\Курсовая (Магазин компьютерных комплектующих)\\Курсовая (Магазин компьютерных комплектующих)\\image\\Logo\\emtiTovar.png";
                }
            }
                
        }
    }
}
