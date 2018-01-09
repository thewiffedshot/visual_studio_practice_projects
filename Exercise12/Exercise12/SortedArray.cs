using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12
{
    class SortedArray
    {
        decimal[] container = new decimal[0];
        decimal[] placeHolder;

        public int BinarySearch(decimal v)
        {
            int p = LowerBound(v);

            if (p >= 0 && p < container.Length && container[p] == v) return p; else return -1;
        }

        public int LowerBound(decimal v)
        {
            int start = 0, end = container.Length, mid;

            while (start < end)
            {
                mid = start + (end - start) / 2;

                if (container[mid] == v)
                {
                    return mid;
                }
                else if (container[mid] > v)
                {
                    end = mid;
                }
                else if (container[mid] < v)
                {
                    start = mid + 1;
                }           
            }

            return start;
        }

        public void Add(decimal v)
        {
            if (container.Length == 0)
            {
                container = new decimal[1];
                container[0] = v;
            }
            else
            {
                int pos = LowerBound(v);

                if (pos == container.Length || container[pos] != v)
                {
                    placeHolder = new decimal[container.Length + 1];

                    for (int i = 0; i < placeHolder.Length; i++)
                    {
                        if (i < pos) placeHolder[i] = container[i];
                        else if (i == pos) placeHolder[i] = v;
                        else if (i > pos) placeHolder[i] = container[i - 1];
                    }

                    container = placeHolder;
                }
            }
        }

        public decimal[] ToArray()
        {
            return container;
        }

        public override string ToString()
        {
            string result = "[";

            foreach (var elem in container)
                result += elem.ToString() + ' ';

            result += ']';

            return result;
        }
    }
}
