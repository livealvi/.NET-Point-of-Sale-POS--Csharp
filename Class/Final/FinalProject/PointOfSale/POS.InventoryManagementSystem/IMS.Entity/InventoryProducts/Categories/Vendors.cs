using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    public class Vendors
    {
        public int      VendorId         { get; set; }
        public string   VendorTag        { get; set; }
        public string   VendorName       { get; set; }
        public int      ThirdCategoryId  { get; set; }
        public string   VendorDescription{ get; set; }
        public string   VendorStatus     { get; set; }
        public byte[]   VendorImage      { get; set; }
        public DateTime RegisterDate     { get; set; }

        //Outside
        public string ThirdCategoryName{ get; set; }

        public virtual ICollection<Brands> Brands       { get; set; }
        public virtual ThirdCategories     ThirdCategory{ get; set; }
    }
}
