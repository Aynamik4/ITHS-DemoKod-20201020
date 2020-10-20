using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericsCodeAlong
{
    class ListOfPersonAlmost : IEnumerable<Person>, IEnumerator<Person>
    {
        Person[] people = new Person[2];
        int usedElementsInPeople = 0;
        int loopIndex = -1;

        public void Add(Person p)
        {
            if(usedElementsInPeople == people.Length)
            {
                Person[] temp = new Person[people.Length * 2];

                for (int i = 0; i < people.Length; i++)
                {
                    temp[i] = people[i];
                }

                people = temp;
            }

            people[usedElementsInPeople] = p;
            usedElementsInPeople++;
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
