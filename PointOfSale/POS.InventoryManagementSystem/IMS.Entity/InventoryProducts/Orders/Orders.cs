using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    public class Orders
    {
        public int      OrderId      { get; set; }
        public int      Id       { get; set; }
        public int      BarCodeId    { get; set; }
        public DateTime Date         { get; set; }
        public int      OrderQuantity{ get; set; }
        public int      ProductId    { get; set; }
        //public Nullable<int>             Quantity           { get; set; }
        
        public double ProductMSRP        { get; set; }
        public string           Status             { get; set; }
        public double TotalAmount        { get; set; }

        //OutSide - Products
        public string ProductIdTag       { get; set; }
        public string ProductName        { get; set; }
        public double ProductPerUnitPrice{ get; set; }
        public string ProductStatus      { get; set; }
        public int    ProductUnitStock   { get; set; }
        public double ProductDiscountRate{ get; set; }
        public string OrderStatus        { get; set; }
        public string PaymentMethod      { get; set; }
        
        //OutSide - Customers
        public string CustomerFullName{ get; set; }
        public string CustomerPhone   { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail   { get; set; }

        //OutSide - Users
        public string FirstName{ get; set; }
        public string Role     { get; set; }

        //OutSide - Brands
        public string BrandName{ get; set; }

        //OutSide - Vendor
        public string VendorName{ get; set; }

        //OutSide - ThirdCategory
        public string ThirdCategoryName{ get; set; }

        //OutSide - Second Category 
        public string SecondCategoryName{ get; set; }

        public virtual BarCodes BarCode{ get; set; }
        public virtual Users    User   { get; set; }
        public virtual Products Product{ get; set; }
        
        public virtual ICollection<OrdersProductsMap> OrdersProductsMaps{ get; set; }

    }
}
