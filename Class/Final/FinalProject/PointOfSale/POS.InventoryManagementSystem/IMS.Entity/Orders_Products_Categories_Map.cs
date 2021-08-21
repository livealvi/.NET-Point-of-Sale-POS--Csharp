using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Orders_Products_Categories_Map
    {
        public int                       OrderProductsCategoriesId{ get; set; }
        public Nullable<int>             OrderId                  { get; set; }
        public int                       CategoriesProductsId     { get; set; }
        public Nullable<double>          UnitPrice                { get; set; }
        public byte[]                    OrderNumber              { get; set; }
        public Nullable<int>             OrderQuantity            { get; set; }
        public Nullable<double>          OrderDiscount            { get; set; }
        public Nullable<System.DateTime> OrderDate                { get; set; }

        public virtual Orders                       Order                  { get; set; }
        public virtual Orders_Products_Categories_Map Products_Categories_Map{ get; set; }
    }
}
