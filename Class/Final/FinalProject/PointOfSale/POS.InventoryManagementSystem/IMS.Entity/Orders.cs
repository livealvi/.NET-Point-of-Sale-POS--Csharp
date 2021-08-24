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
        public string            OrderTag           { get; set; }
        public DateTime Date               { get; set; }
        public Nullable<int>             ProductId          { get; set; }
        //public Nullable<int>             Quantity           { get; set; }
        public Nullable<double>  ProductDiscountRate{ get; set; }
        public Nullable<double> ProductMSRP        { get; set; }
        public string           Status             { get; set; }
        public Nullable<double> TotalAmount        { get; set; }


        //OutSide - Products
        public string           ProductIdTag       { get; set; }
        public string           ProductName        { get; set; }
        public Nullable<double> ProductPerUnitPrice{ get; set; }
        public string           ProductStatus      { get; set; }
        public int              ProductUnitStock   { get; set; }

        //OutSide - Customers
        public string CustomerFullName{ get; set; }
        public string Phone           { get; set; }
        public string Address         { get; set; }
        public string Email           { get; set; }

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


        public virtual BarCodes   BarCode { get; set; }
        public virtual Customers Customer{ get; set; }
        public virtual Users     User    { get; set; }
        public virtual Products  Product { get; set; }
        
        public virtual ICollection<OrdersProductsMap> OrdersProductsMaps{ get; set; }

    }
}
