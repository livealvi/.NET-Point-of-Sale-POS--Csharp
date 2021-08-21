using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Vendors
    {
        public int           VendorId         { get; set; }
        public string        VendorName       { get; set; }
        public Nullable<int> ThirdCategoryId  { get; set; }
        public string        VendorDescription{ get; set; }
        public byte[]        VendorImage      { get; set; }

        public virtual ICollection<Brands> Brands{ get; set; }
        public virtual ICollection<Products_Categories_Map> Products_Categories_Map{ get; set; }
        public virtual ThirdCategories ThirdCategory{ get;                                  set; }
    }
}
