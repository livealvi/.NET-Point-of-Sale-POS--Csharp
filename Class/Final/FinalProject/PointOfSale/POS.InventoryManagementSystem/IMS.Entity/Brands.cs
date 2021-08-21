using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Brands
    {
        public int           BrandId         { get; set; }
        public string        BrandTag       { get; set; }
        public string        BrandName       { get; set; }
        public Nullable<int> VendorId        { get; set; }
        public string        BrandDescription{ get; set; }
        public string        BrandStatus     { get; set; }
        public byte[]        BrandImage      { get; set; }

        //outside
        public string VendorName{get; set;} 

        public virtual Vendors Vendor{ get; set; }
        public virtual ICollection<Products> Products{ get; set; }
        public virtual ICollection<Products_Categories_Map> Products_Categories_Map{ get; set; }

    }
}
