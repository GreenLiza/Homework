namespace Phone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();

            Console.WriteLine();

            company.newSubscriberAdder.ChangeSubscribersTariff(company.subscribers, company.tariffs, 1);
            company.newSubscriberAdder.ChangeSubscribersTariff(company.subscribers, company.tariffs, 1);
            company.newSubscriberAdder.ChangeSubscribersSimCard(company.subscribers, 2);
            company.newSubscriberAdder.ChangeSubscribersPhoneNumber(company.subscribers, company.phoneNumbers, 3);
            
            Console.WriteLine();

            company.CallTo(1, company.GetSubscriberNumberByID(2));
            company.CallTo(1, company.GetSubscriberNumberByID(3));
            company.subscribers[2].CurrentSimCard.SimCardStatus = SimCardStatuses.Flight;
            company.CallTo(3, company.GetSubscriberNumberByID(2));
            company.subscribers[2].CurrentSimCard.SimCardStatus = SimCardStatuses.Active;
            company.CallTo(2, company.GetSubscriberNumberByID(3));
            

            Console.WriteLine();

            for (int i = 1; i <= company.subscribers.Count; i++)
            {
                Console.WriteLine($"Subscriber {i} ({company.subscribers[i].Name}) total month rate = {company.subscribers[i].GetTotalPriceOfCallsForMonth() + company.subscribers[i].Tariff.MonthRate}");
            }

            Console.WriteLine();

            Console.WriteLine("Statistics:");
            
            company.subscribers[1].PrintCallsSortedByDate();
            company.subscribers[2].PrintCallsSortedByPrice();
            company.subscribers[2].PrintCallsSortedBySubscriberTo();


        }
    }
}