using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    public class Subscriber
    {
        public string Name;
        public int PhoneNumber;
        private SimCard currentSimCard;
        public SimCard CurrentSimCard 
        {
            get { return currentSimCard; }
            set 
            {
                if (currentSimCard != value)
                {
                    currentSimCard = value;
                    CurrentSimCard.Notify += CurrentSimCard_Notify;
                }
               
            }
        }
        public string PhoneModel;
        public Tariffs Tariff;
        public List<Call> ListOfInComeCalls = new List<Call>();
        public List<Call> ListOfOutComeCalls = new List<Call>();

        public Subscriber(string name, int phoneNumber, SimCard simCard, string phoneModel, Tariffs tariff)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            CurrentSimCard = simCard;
            PhoneModel = phoneModel;
            Tariff = tariff;
        }

        private void CurrentSimCard_Notify(string status, string ID)
        {
            Console.WriteLine($"SIM card status was changed to {status}");
        }

        public int GetTotalPriceOfCallsForMonth()
        {
            return ListOfOutComeCalls.Where(x => x.CallStart <= DateTime.Now &&
            x.CallStart >= DateTime.Now - TimeSpan.FromDays(30)).Sum(x => x.CallPrice);

        }

        public void PrintCallsSortedByDate()
        {
            Console.WriteLine($"{this.Name}'s calls sorted by start time:");
            var sortedCalls = ListOfOutComeCalls.OrderBy(x => x.CallStart).ToList();
            for (int i = 0; i < sortedCalls.Count(); i++)
            {
                Console.WriteLine($"Start {sortedCalls[i].CallStart}. End {sortedCalls[i].CallEnd}. From {sortedCalls[i].SubscriberFrom.Name} to {sortedCalls[i].SubscriberTo.Name}.");
            }
        }

        public void PrintCallsSortedByPrice()
        {
            Console.WriteLine($"{this.Name}'s calls sorted by price:");
            var sortedCalls = ListOfOutComeCalls.OrderBy(x => x.CallPrice).ToList();
            for (int i = 0; i < sortedCalls.Count(); i++)
            {
                Console.WriteLine($"From {sortedCalls[i].SubscriberFrom.Name} to {sortedCalls[i].SubscriberTo.Name}. Price {sortedCalls[i].CallPrice}.");
            }
        }

        public void PrintCallsSortedBySubscriberTo()
        {
            Console.WriteLine($"{this.Name}'s calls sorted by recipient:");
            var sortedCalls = ListOfOutComeCalls.OrderBy(x => x.SubscriberTo.PhoneNumber).ToList();
            for (int i = 0; i < sortedCalls.Count(); i++)
            {
                Console.WriteLine($"From {sortedCalls[i].SubscriberFrom.Name} to {sortedCalls[i].SubscriberTo.Name}. Start {sortedCalls[i].CallStart}. End {sortedCalls[i].CallEnd}. ");
            }
        }

    }
}
