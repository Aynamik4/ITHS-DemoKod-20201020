using System;
using System.Collections.Generic;
using System.Text;

namespace NonGenericListDemo
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Age => DateTime.Now.Year - BirthYear;
    }
}
