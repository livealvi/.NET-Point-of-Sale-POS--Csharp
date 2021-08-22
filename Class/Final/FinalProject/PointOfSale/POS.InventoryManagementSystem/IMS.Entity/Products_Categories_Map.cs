using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Products_Categories_Map
    {
        public int           CategoriesProductsId{ get; set; }
        public Nullable<int> ProductId           { get; set; }
        public Nullable<int> BrandId             { get; set; }
        public Nullable<int> VendorId            { get; set; }
        public Nullable<int> ThirdCategoryId     { get; set; }
        public Nullable<int> SecondCategoryId    { get; set; }
        public Nullable<int> MainCategoryId      { get; set; }

        //OutSide Products
        public string           ProductIdTag          { get; set; }
        public string           ProductName           { get; set; }
        public string           ProductDescription    { get; set; }
        public Nullable<double> ProductQuantityPerUnit{ get; set; }
        public Nullable<double> ProductPerUnitPrice   { get; set; }
        public Nullable<double> ProductMSRP           { get; set; }
        public string           ProductStatus         { get; set; }
        public Nullable<double> ProductDiscountRate   { get; set; }
        public Nullable<double> ProductSize           { get; set; }
        public string           ProductColor          { get; set; }
        // public byte[]           ProductPictures       { get; set; }
        public Nullable<double> ProductWeight   { get; set; }
        public string           ProductUnitStock{ get; set; }


        //OutSide - Category
        public string BrandName         { get; set; }
        public string VendorName        { get; set; }
        public string ThirdCategoryName {get;  set;}
        public string SecondCategoryName{get;  set;}
        public string MainCategoryName  { get; set; }

        public virtual Brands         Brands         { get; set; }
        public virtual MainCategories MainCategories{ get; set; }

        
        public virtual Products        Products       { get;                                              set; }
        public virtual SecondCategories SecondCategories { get;                                              set; }
        public virtual ThirdCategories ThirdCategories { get;                                              set; }
        public virtual Vendors         Vendors        { get;                                              set; }

    }
    
}
