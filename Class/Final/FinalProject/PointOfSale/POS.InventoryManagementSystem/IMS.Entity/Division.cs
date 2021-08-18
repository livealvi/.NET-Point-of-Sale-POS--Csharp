using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Division
    {
        public         int                    DivisionId  { get; set; }
        public         string                 DivisionName{ get; set; }
        public virtual ICollection<Customer> Customers   { get; set; }
    }
}
