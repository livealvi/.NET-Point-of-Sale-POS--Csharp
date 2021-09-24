using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    public class Users
    {
        public int      Id         { get; set; }
        public string   UserId     { get; set; }
        public string   FirstName  { get; set; }
        public string   LastName   { get; set; }
        public string   Password   { get; set; }
        public string   Email   { get; set; }
        public int      Age        { get; set; }
        public string   Gender     { get; set; }
        public string   Role       { get; set; }
        public double   Salary     { get; set; }
        public DateTime JoinDate   { get; set; }
        public DateTime Birthdate  { get; set; }
        public string   NID        { get; set; }
        public string   Phone      { get; set; }
        public string   HomeTown   { get; set; }
        public string   CurrentCity{ get; set; }
        public string   Division   { get; set; }
        public string   BloodGroup { get; set; }
        public int      PostalCode { get; set; }

        public virtual ICollection<Orders> Orders{ get; set; }
    }
}
