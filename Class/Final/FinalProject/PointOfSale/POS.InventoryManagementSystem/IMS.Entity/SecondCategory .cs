using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class SecondCategory
    {
        public int           SecondCategoryId         { get; set; }
        public string        SecondCategoryName       { get; set; }
        public Nullable<int> MainCategoryId           { get; set; }
        public string        SecondCategoryDescription{ get; set; }
        public byte[]        SecondCategoryImage      { get; set; }

        public virtual MainCategorie              MainCategory   { get; set; }
        public virtual ICollection<ThirdCategory> ThirdCategories{ get; set; }

    }
}
