using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Order
    {
        public int                       OrderId    { get; set; }
        public int                       EmployeeId { get; set; }
        public int                       CustomerId { get; set; }
        public Nullable<int>             OrderNumber{ get; set; }
        public Nullable<System.DateTime> OrderDate  { get; set; }
        public int                       PaymentId  { get; set; }
        public string                    Paid       { get; set; }
        public Nullable<System.DateTime> PaymentDate{ get; set; }
        public byte[]                    PaymentTime{ get; set; }

        public virtual Customer Customer{ get; set; }

        public virtual ICollection<Order_Product_Map> Orders_Products_Map{ get; set; }

    }
}
