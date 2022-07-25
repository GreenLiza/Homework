namespace Phone
{
    internal class SubscriberAdderChanger
    {
        public delegate void SubscriberSimCardChange(Subscriber subscriber);
        public event SubscriberSimCardChange SubscriberSimCardChangeNotify;

        private List<string> _names = new List<string> {"Adam", "Andy", "Amy", "Bob", "Bill", "Diana", "Fred", "George", "Gloria" };

        private int GetRandomListValue<T>(List<T> list)
        {
            var i = new Random().Next(list.Count - 1);
            return i;
        }
        public Subscriber AddNewSubscriber(List<int> phoneNumbers, List<string> phoneModels, List<Tariffs> tariffs)
        {
            var name = _names[GetRandomListValue(_names)];
            var phoneNumber = UniqueNumberGenerator.CreateNewPhoneNumber(phoneNumbers);
            var phoneModel = phoneModels[GetRandomListValue(phoneModels)];
            var simCard = new SimCard();
            var tariff = tariffs[GetRandomListValue(tariffs)];
            var person = new Subscriber(name, phoneNumber, simCard, phoneModel, tariff);
            return person;
        }

        public void ChangeSubscribersPhoneNumber(Dictionary<int, Subscriber> subscribers, List<int> phoneNumbers, int subscriberID)
        {
            if (subscribers.ContainsKey(subscriberID))
            {
                subscribers[subscriberID].PhoneNumber = UniqueNumberGenerator.CreateNewPhoneNumber(phoneNumbers);
                Console.WriteLine($"Subscribers {subscriberID} ({subscribers[subscriberID].Name}) new phone number - {subscribers[subscriberID].PhoneNumber}");

            }
            else
            {
                Console.WriteLine("Subscriber ID doesn't exist.");
            }
        }

        public void ChangeSubscribersSimCard(Dictionary<int, Subscriber> subscribers, int subscriberID)
        {
            if (subscribers.ContainsKey(subscriberID))
            {
                subscribers[subscriberID].CurrentSimCard = new SimCard();
                SubscriberSimCardChangeNotify?.Invoke(subscribers[subscriberID]);
                Console.WriteLine($"Subscribers {subscriberID} ({subscribers[subscriberID].Name}) new SIM card ID - {subscribers[subscriberID].CurrentSimCard.SimCardID}");

            }
            else
            {
                Console.WriteLine("Subscriber ID doesn't exist.");
            }
        }

        public void ChangeSubscribersPhone(Dictionary<int, Subscriber> subscribers, List<string> phoneModels, int subscriberID)
        {
            if (subscribers.ContainsKey(subscriberID))
            {
                subscribers[subscriberID].PhoneModel = phoneModels[GetRandomListValue(phoneModels)];
                Console.WriteLine($"Subscribers {subscriberID} ({subscribers[subscriberID].Name}) new phone is {subscribers[subscriberID].PhoneModel}");

            }
            else
            {
                Console.WriteLine("Subscriber ID doesn't exist.");
            }
        }

        public void ChangeSubscribersTariff(Dictionary<int, Subscriber> subscribers, List<Tariffs> tariffs, int subscriberID)
        {
            if (subscribers.ContainsKey(subscriberID))
            {
                if (DateTime.Now - subscribers[subscriberID].Tariff.LastModification >= TimeSpan.FromDays(30))
                {
                    var newTariff = tariffs[GetRandomListValue(tariffs)];
                    while (newTariff == subscribers[subscriberID].Tariff)
                    {
                        newTariff = tariffs[GetRandomListValue(tariffs)];
                    }
                    subscribers[subscriberID].Tariff = newTariff;
                    subscribers[subscriberID].Tariff.LastModification = DateTime.Now;
                    Console.WriteLine($"Subscribers {subscriberID} ({subscribers[subscriberID].Name}) new tariff is {subscribers[subscriberID].Tariff.Name}");
                }
                else
                {
                    Console.WriteLine("Tariff can be changed once in 30 days.");
                }
            }
            else
            {
                Console.WriteLine("Subscriber ID doesn't exist.");
            }
        }
    }
}