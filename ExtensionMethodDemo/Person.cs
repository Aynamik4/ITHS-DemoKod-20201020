using System;

namespace ExtensionMethodDemo
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Age => DateTime.Now.Year - BirthYear;
    }
}
