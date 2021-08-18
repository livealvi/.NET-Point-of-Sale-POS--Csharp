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

        public virtual ThirdCategory ThirdCategory{ get; set; }

    }
}
