using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Orders
    {
        public int                       OrderId    { get; set; }
        public int                       EmployeeId { get; set; }
        public int                       CustomerId { get; set; }
        public Nullable<int>             OrderNumber{ get; set; }
        public Nullable<System.DateTime> OrderDate  { get; set; }
        public string                    Paid       { get; set; }

        public virtual Customers Customer{ get; set; }
        public virtual Users Employee{ get; set; }
        
        public virtual ICollection<OrdersProductsMap> OrdersProductsMaps{ get; set; }

    }
}
