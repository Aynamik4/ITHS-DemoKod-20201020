using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericsCodeAlong
{
    class ListOfPerson : IEnumerable, IEnumerator
    {
        Person[] people = new Person[4];
        int usedElementsInPeople = 0;
        int loopIndex = -1;

        public void Add(Person p)
        {
            people[usedElementsInPeople] = p;
            usedElementsInPeople++;
        }

        public object Current => people[loopIndex];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            loopIndex++;
            bool keepGoing = loopIndex < usedElementsInPeople;

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
