using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericsCodeAlong
{
    class MyList<T> : IEnumerable<T>, IEnumerator<T>
    {
        T[] people = new T[2];
        int usedElementsInPeople = 0;
        int loopIndex = -1;

        public void Add(T p)
        {
            if (usedElementsInPeople == people.Length)
            {
                T[] temp = new T[people.Length * 2];

                for (int i = 0; i < people.Length; i++)
                {
                    temp[i] = people[i];
                }

                people = temp;
            }

            people[usedElementsInPeople] = p;
            usedElementsInPeople++;
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
            return loopIndex < usedElementsInPeople;
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
