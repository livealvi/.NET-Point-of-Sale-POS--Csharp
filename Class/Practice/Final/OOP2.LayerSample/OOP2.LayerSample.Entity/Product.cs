using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OOP2.LayerSample.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string PName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice{ get; set; }
    }
}
