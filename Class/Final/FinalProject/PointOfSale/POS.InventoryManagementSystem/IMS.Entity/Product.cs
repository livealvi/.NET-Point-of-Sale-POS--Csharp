using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Product
    {
        public int              ProductId             { get; set; }
        public string           ProductIdTag          { get; set; }
        public string           ProductName           { get; set; }
        public Nullable<int>    BrandId               { get; set; }
        public string           ProductDescription    { get; set; }
        public Nullable<double> ProductQuantityPerUnit{ get; set; }
        public Nullable<double> ProductPerUnitPrice   { get; set; }
        public Nullable<double> ProductMSRP           { get; set; }
        public string           ProductStatus         { get; set; }
        public Nullable<double> ProductDiscountRate   { get; set; }
        public Nullable<double> ProductSize           { get; set; }
        public string           ProductColor          { get; set; }
        public byte[]           ProductPictures       { get; set; }
        public string           ProductWeight         { get; set; }
        public string           ProductUnitStock      { get; set; }

        public virtual Brand                           Brand              { get; set; }
        public virtual ICollection<Order_Product_Map> Orders_Products_Map{ get; set; }

    }
}
