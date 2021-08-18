using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class ThirdCategory
    {
        public int           ThirdCategoryId         { get; set; }
        public string        ThirdCategoryName       { get; set; }
        public Nullable<int> SecondCategoryId        { get; set; }
        public string        ThirdCategoryDescription{ get; set; }
        public byte[]        ThirdCategoryImage      { get; set; }
        public string        SecondCategoryName      { get; set; }

        public virtual SecondCategory       SecondCategory{ get; set; }
        public virtual ICollection<Vendors> Vendors       { get; set; }

    }
}
