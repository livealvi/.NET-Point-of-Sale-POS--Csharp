using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Customer
    {
        public int           CustomerId       { get; set; }
        public string        CustomerFirstName{ get; set; }
        public string        CustomerLastName { get; set; }
        public Nullable<int> Age              { get; set; }
        public string        Gender           { get; set; }
        public string        Phone            { get; set; }
        public string        Email            { get; set; }
        public string        Thana            { get; set; }
        public string        HomeTown         { get; set; }
        public string        CurrentCity      { get; set; }
        public Nullable<int> PostalCode       { get; set; }
        public int           DivisionId       { get; set; }
    }
}
