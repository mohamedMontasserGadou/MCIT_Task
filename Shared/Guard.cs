using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCIT_Task.Shared
{
    public class Guard
    {
        public static void AssertStringIsValid(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new Exception("String value is not valid");
        }

        public static void AssertValueGreaterThanZero(int value)
        {
            if (value < 0)
                throw new Exception("value can't be less than zero");
        }

        public static void AssertValueGreaterThanZero(decimal value)
        {
            if (value < 0)
                throw new Exception("value can't be less than zero");
        }

        public static void AssertCollectionIsNotNullOrEmpty(IEnumerable<object> collection)
        {
            if (collection == null || collection.Count() == 0)
                throw new Exception("Collection can't be null or empty");
        }
    }
}
