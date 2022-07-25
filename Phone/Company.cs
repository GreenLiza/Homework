using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    internal class Company
    {
        public List<int> phoneNumbers = new List<int>();
        public List<Tariffs> tariffs = new List<Tariffs>();
        public Dictionary<int, Subscriber> subscribers = new Dictionary<int, Subscriber>();
        private int _subscriberID = 1;

        public List<string> phoneModels = new List<string> { "Nokia", "Samsung", "Apple", "LG" };

        public SubscriberAdderChanger newSubscriberAdder = new();

        public Company()
        {
            CreateTariffsList();
            InitSubscribersDictionary();
            PrintSunscribersInfo();
            newSubscriberAdder.SubscriberSimCardChangeNotify += NewSubscriberAdder_SubscriberSimCardChangeNotify;
        }

        private void NewSubscriberAdder_SubscriberSimCardChangeNotify(Subscriber subscriber)
        {
            subscriber.CurrentSimCard.Notify += CurrentSimCard_Notify;
        }

        private void CreateTariffsList()
        {
            var Tariff1 = new Tariffs("#1", 10, 0);
            var Tariff2 = new Tariffs("#2", 5, 5);
            var Tariff3 = new Tariffs("#3", 0, 10);

            tariffs.Add(Tariff1);
            tariffs.Add(Tariff2);
            tariffs.Add(Tariff3);


        }

        private void InitSubscribersDictionary()
        {
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                var NewSubscriber = newSubscriberAdder.AddNewSubscriber(phoneNumbers, phoneModels, tariffs);
                NewSubscriber.CurrentSimCard.Notify += CurrentSimCard_Notify;
                subscribers.Add(_subscriberID++, NewSubscriber);
            }
        }

        private void PrintSunscribersInfo()
        {
            Console.WriteLine("Subscribers: ");
            for (int i = 1; i <= subscribers.Count; i++)
            {
                Console.WriteLine($"Subscriber {i} - {subscribers[i].Name}, phone number - {subscribers[i].PhoneNumber}, tariff - {subscribers[i].Tariff.Name}, phone model - {subscribers[i].PhoneModel}.");
            }
        }

        private void CurrentSimCard_Notify(string status, string ID)
        {
            Console.WriteLine($"SIM card {ID} status was changed to {status}");
        }


        public int GetSubscriberNumberByID(int subscriberID)
        {
            if (subscribers.ContainsKey(subscriberID))
            {
                return subscribers[subscriberID].PhoneNumber;
            }
            else
            {
                return 0;
            }

        }

        public void CallTo(int subscriberFromID, int phoneNumberTo)
        {

            if (!subscribers.ContainsKey(subscriberFromID))

            {
                Console.WriteLine($"The id {subscriberFromID} doesn't exist.");

                return;
            }

            var subscriberFrom = subscribers[subscriberFromID];

            var subscriberTo = subscribers.Values.FirstOrDefault(x => x.PhoneNumber == phoneNumberTo);

            if (subscriberTo == null)
            {
                Console.WriteLine($"The number {phoneNumberTo} doesn't exist.");
                return;
            }

            if (subscriberFrom.CurrentSimCard.SimCardStatus != SimCardStatuses.Active)
            {
                Console.WriteLine($"The number {subscriberFrom.PhoneNumber} is not available.");
                return;
            }

            if (subscriberTo.CurrentSimCard.SimCardStatus != SimCardStatuses.Active)
            {
                Console.WriteLine($"The number {subscriberTo.PhoneNumber} is not available.");
                return;
            }

            if (subscriberFrom == subscriberTo)
            {
                Console.WriteLine();
            }

            Call outComeCall = new Call(subscriberFrom, subscriberTo);
            Call inComeCall = outComeCall with { CallPrice = 0 };


            subscriberFrom.ListOfOutComeCalls.Add(outComeCall);
            subscriberTo.ListOfInComeCalls.Add(inComeCall);

        }


    }
}
