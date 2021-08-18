using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Order_Product_Map
    {
        public int                       OrderInfoId  { get; set; }
        public Nullable<int>             OrderId      { get; set; }
        public int                       ProductId    { get; set; }
        public Nullable<double>          UnitPrice    { get; set; }
        public byte[]                    OrderNumber  { get; set; }
        public Nullable<int>             OrderQuantity{ get; set; }
        public Nullable<double>          OrderDiscount{ get; set; }
        public Nullable<System.DateTime> OrderDate    { get; set; }

        public virtual Order   Order  { get; set; }
        public virtual Product Product{ get; set; }
    }
}
