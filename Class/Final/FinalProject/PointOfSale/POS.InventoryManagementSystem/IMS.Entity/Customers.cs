using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Customers
    {
        public int    CustomerId      { get; set; }
        public string CustomerFullName{ get; set; }
        public string Phone           { get; set; }
        public string Address         { get; set; }
        public string Email           { get; set; }

        public virtual ICollection<Orders> Orders{ get; set; }
    }
}
