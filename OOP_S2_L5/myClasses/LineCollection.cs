using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public class LineCollection : IEnumerable<IColoredLine>
    {
        private ArrayList list;
        private List<IColoredLine> genericList;

        public LineCollection()
        {
            list = new ArrayList();
            genericList= new List<IColoredLine>();
        }

        public void AddToList(IColoredLine line)
        {
            list.Add(line);
        }

        public void AddToGenereicList(IColoredLine line) 
        {
            genericList.Add(line);
        }

        public void Add(IColoredLine line)
        {
            genericList.Add(line);
            list.Add(line);
        }

        public IColoredLine GetFromList(int index)
        {
            IEnumerator <IColoredLine> enumerator = (IEnumerator<IColoredLine>)list.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                if (i == index) 
                { 
                    return enumerator.Current;
                }
                i++;
            }
            throw new IndexOutOfRangeException();
        }

        public IColoredLine GetFromGenericList(int index)
        {
            return genericList[index];
        }

        public void RemoveFromList(int index)
        {
            list.RemoveAt(index);
        }

        public void RemoveFromGenereicList(int index)
        {
            genericList.RemoveAt(index);
        }

        public IEnumerator<IColoredLine> GetEnumerator()
        {
            return ((IEnumerable<IColoredLine>)genericList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }

    }
}