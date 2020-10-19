using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NonGenericListDemo
{
    class PersonList : IEnumerable, IEnumerator
    {
        Person[] people = new Person[2];
        int actualLength = 0;
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
            if(actualLength == people.Length)
            {
                Person[] tempArray = new Person[people.Length * 2];

                for (int i = 0; i < people.Length; i++)
                    tempArray[i] = people[i];

                people = tempArray;
            }

            people[actualLength] = p;
            actualLength++;
        }

        public object Current => people[loopIndex];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            loopIndex++;
            bool keepGoing = loopIndex < actualLength;

            if (!keepGoing)
                Reset();

            return keepGoing;
        }

        public void Reset()
        {
            loopIndex = -1;
        }
    }
}
