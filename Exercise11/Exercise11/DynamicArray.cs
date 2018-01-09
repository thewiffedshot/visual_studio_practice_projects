using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    class DynamicArray
    {
        byte[] container;
        byte[] placeHolder;

        public void AddRange(byte[] range, int count)
        {
            if (container == null)
            {
                container = new byte[count];
                for (int i = 0; i < count; i++)
                    container[i] = range[i];
            }
            else
            {
                placeHolder = new byte[container.Length + count];

                for (int i = 0; i < container.Length; i++)
                    placeHolder[i] = container[i];

                container = placeHolder;

                for (int i = 0; i < count; i++)
                {                  
                    container[placeHolder.Length - count + i] = range[i];
                }               
            }
        }

        public byte[] ToArray()
        {
            return container;
        }
    }
}
