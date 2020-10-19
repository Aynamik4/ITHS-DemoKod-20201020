using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NonGenericListDemo
{
    class GenericList<T> : IEnumerable<T>, IEnumerator<T>
    {
        T[] people = new T[1];
        int usedLength = 0;
        int loopIndex = -1;

        public T this[int index]
        {
            get
            { /* return the specified index here */
                return people[index];
            }
            set
            { /* set the specified index to value here */
                people[index] = value;
            }
        }

        public void Add(T p)
        {
            if (usedLength == people.Length)
            {
                T[] tmp = new T[people.Length * 2];

                for (int i = 0; i < people.Length; i++)
                    tmp[i] = people[i];

                people = tmp;
            }

            people[usedLength] = p;
            usedLength++;
        }

        public T Current => people[loopIndex];

        object IEnumerator.Current => people[loopIndex];

        public void Dispose()
        {
            Reset();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            loopIndex++;
            return loopIndex < usedLength;
        }

        public void Reset()
        {
            loopIndex = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}
