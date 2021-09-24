using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAppDel
{
    internal class GenericClass <T>
    {
        private T ax;

        public T Ax
        {
            get {return this.ax;}
            set {this.ax = value;}
        }

        public T M1(T d)
        {
            return d;
        }

        public T[] rx = new T[5];

        public string ZZ{set; get;}



    }
}
