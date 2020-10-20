using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethodCodeAlong
{
    static class ExtensionMethods // Extension methods can only exist in a static class.
    {
        public static bool IsOdd(this int i) // Extension methods are always static and 
        {                                    // prefixes its first parameter with the
            return i % 2 == 1;               // keyword "this".
        }

        static public int ToInt(this string s)
        {
            int.TryParse(s, out int i);
            return i;
        }
    }
}
