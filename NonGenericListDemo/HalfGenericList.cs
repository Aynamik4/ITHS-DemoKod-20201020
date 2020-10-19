using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NonGenericListDemo
{
    class HalfGenericList : IEnumerable<Person>, IEnumerator<Person>
    {
        Person[] people = new Person[1];
        int usedLength = 0;
        int loopIndex = -1;

        public Person this[int index]
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

        public void Add(Person p)
        {
            if(usedLength == people.Length)
            {
                Person[] tmp = new Person[people.Length * 2];

                for (int i = 0; i < people.Length; i++)
                    tmp[i] = people[i];

                people = tmp;
            }

            people[usedLength] = p;
            usedLength++;
        }

        public Person Current => people[loopIndex];

        object IEnumerator.Current => people[loopIndex];

        public void Dispose()
        {
            Reset();
        }

        public IEnumerator<Person> GetEnumerator()
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
