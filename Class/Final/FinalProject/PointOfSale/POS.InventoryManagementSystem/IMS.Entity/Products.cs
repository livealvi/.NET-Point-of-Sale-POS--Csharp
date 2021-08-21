using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Products
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
       // public byte[]           ProductPictures       { get; set; }
        public Nullable<double> ProductWeight         { get; set; }
        public string           ProductUnitStock      { get; set; }

        //outside
        public string BrandName{ get; set; }

        public virtual Brands Brand{ get; set; }
        public virtual ICollection<Products_Categories_Map> Products_Categories_Map{ get; set; }

    }
}
