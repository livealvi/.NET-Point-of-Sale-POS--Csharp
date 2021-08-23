using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Orders
    {
        public int                       OrderId            { get; set; }
        public int                       UserId             { get; set; }
        public int                       CustomerId         { get; set; }
        public Nullable<int>             BarCodeId          { get; set; }
        public Nullable<int>             OrderTag           { get; set; }
        public Nullable<System.DateTime> Date               { get; set; }
        public Nullable<int>             ProductId          { get; set; }
        public Nullable<int>             Quantity           { get; set; }
        public string                    ProductDiscountRate{ get; set; }
        public Nullable<double>          ProductMSRP        { get; set; }
        public string                    Status             { get; set; }

        public virtual BarCodes   BarCode { get; set; }
        public virtual Customers Customer{ get; set; }
        public virtual Users     User    { get; set; }
        public virtual Products  Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersProductsMap> OrdersProductsMaps{ get; set; }

    }
}
