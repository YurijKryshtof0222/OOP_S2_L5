using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public interface IVectorComparable : IComparable
    {
        double XKey();
        double YKey();

        /*int CompareTo(object obj)
        {
            if (this == obj) return 0;
            if (this == null) throw new NullReferenceException();

            IVectorComparable another = obj as IVectorComparable;
            int xCompare = this.XKey().CompareTo(another.YKey());
            if (xCompare != 0)
            {
                return this.YKey().CompareTo(another.YKey());
            }
            return xCompare;
        }*/

    }
}