using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    internal static class UniqueNumberGenerator
    {
        public static int CreateNewPhoneNumber(List<int> phoneNumbers)
        {
            int number = new Random().Next(1000000, 10000000);
            while (phoneNumbers.Contains(number))
            {
                number = new Random().Next(1000000, 10000000);
            }
            phoneNumbers.Add(number);
            return number;
        }

    }
}
