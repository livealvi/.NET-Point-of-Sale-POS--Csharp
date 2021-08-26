using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    public class BarCodes
    {
        public int    BarCodeId{ get; set; }
        public string BarCode1 { get; set; }

        public virtual ICollection<Orders> Orders{ get; set; }
    }
}
