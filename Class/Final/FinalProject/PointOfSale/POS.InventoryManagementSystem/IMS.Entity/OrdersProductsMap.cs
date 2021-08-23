using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    using System;
    using System.Collections.Generic;
    public class OrdersProductsMap
    {
        public int           OrderProductsCategoriesId{ get; set; }
        public Nullable<int> OrderId                  { get; set; }
        public Nullable<int> ProductId                { get; set; }

        public virtual Orders   Order  { get; set; }
        public virtual Products Product{ get; set; }
    }
}
