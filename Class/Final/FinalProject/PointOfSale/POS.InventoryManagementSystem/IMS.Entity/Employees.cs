using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity
{
    public class Employees
    {
        public int                       EmployeeId       { get; set; }
        public string                    EmployeeFirstName{ get; set; }
        public byte[]                    EmployeeLastName { get; set; }
        public Nullable<int>             Age              { get; set; }
        public string                    Gender           { get; set; }
        public string                    Role             { get; set; }
        public Nullable<double>          Salary           { get; set; }
        public Nullable<System.DateTime> JoinDate         { get; set; }
        public Nullable<System.DateTime> Birthdate        { get; set; }
        public string                    NID              { get; set; }
        public string                    Phone            { get; set; }
        public string                    Thana            { get; set; }
        public string                    HomeTown         { get; set; }
        public string                    CurrentCity      { get; set; }
        public Nullable<int>             PostalCode       { get; set; }
        public int                       BloodId          { get; set; }
        public int                       DivisionId       { get; set; }

        public virtual Bloods              Blood   { get; set; }
        public virtual Divisions           Division{ get; set; }
        public virtual ICollection<Orders> Orders  { get; set; }
    }
}
