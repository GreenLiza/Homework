using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    public record Call
    {
        public Subscriber SubscriberFrom { get; private set; }
        public Subscriber SubscriberTo { get; private set; }
        public DateTime CallStart { get; private set; }
        public DateTime CallEnd { get; private set; }
        public int CallPrice { get; set; }


        public Call(Subscriber subscriberFrom, Subscriber subscriberTo)
        {
            SubscriberFrom = subscriberFrom;
            SubscriberTo = subscriberTo;
            SubscriberFrom.CurrentSimCard.SimCardStatus = SimCardStatuses.Call;
            SubscriberTo.CurrentSimCard.SimCardStatus = SimCardStatuses.Call;
            CallStart = DateTime.Now;
            int duration = new Random().Next(1, 60);
            CallEnd = CallStart + TimeSpan.FromMinutes(duration);
            if (CallEnd >= DateTime.Now)
            {
                SubscriberFrom.CurrentSimCard.SimCardStatus = SimCardStatuses.Active;
                SubscriberTo.CurrentSimCard.SimCardStatus = SimCardStatuses.Active;
            }
            CallPrice = duration*subscriberFrom.Tariff.MinutePrice;
        }

        
    }
}
