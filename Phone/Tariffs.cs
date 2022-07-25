using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    public class Tariffs
    {
        public string Name { get; private set; }
        public int MinutePrice { get; private set; }
        public int MonthRate { get; private set; }
        public DateTime LastModification { get; set; }


        public Tariffs(string name, int minutePrice, int monthRate)
        {
            Name = name;
            MinutePrice = minutePrice;
            MonthRate = monthRate;

        }
    }
}
