using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Brand
    {
        public int           BrandId         { get; set; }
        public string        BrandName       { get; set; }
        public Nullable<int> VendorId        { get; set; }
        public string        BrandDescription{ get; set; }
        public string        BrandStatus     { get; set; }
        public byte[]        BrandImage      { get; set; }

        public virtual ICollection<Product> Products{ get; set; }
    }
}
