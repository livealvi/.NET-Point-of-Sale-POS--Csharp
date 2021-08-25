using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class MainCategories
    {
        public int MainCategoryId { get; set; }
        public string MainCategoryName { get; set; }
        public string MainCategoryDescription { get; set; }
        public byte[] MainCategoryImage { get; set; }


        public virtual ICollection<SecondCategories> SecondCategories{ get; set; }
    }
}
