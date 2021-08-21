using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Divisions
    {
        public         int                    DivisionId  { get; set; }
        public         string                 DivisionName{ get; set; }
        public virtual ICollection<Customers> Customers   { get; set; }
    }
}
