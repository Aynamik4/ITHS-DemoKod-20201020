using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsCodeAlong
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        
        // Either like this...
        public int Age => DateTime.Now.Year - BirthYear;

        //// Or like this.
        //public int Age
        //{
        //    get
        //    {
        //        return DateTime.Now.Year - BirthYear;
        //    }
        //}
    }
}
