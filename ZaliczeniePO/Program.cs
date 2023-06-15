using ZaliczeniePO.Domain;
using ZaliczeniePO.Tools;

namespace ZaliczeniePO;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Tag> tags = new List<Tag>();
        tags.Add(new Tag("default", ConsoleColor.Black));
        Person? currentPerson = null;
        bool running = true;

        while (running)
        {
            
            Console.WriteLine("\n1. Login");
            Console.WriteLine("2. Add Person");
            Console.WriteLine("3. Show people");
            Console.WriteLine("4. Add event tag");
            Console.WriteLine("5. Show event tags");

            var choice = Console.ReadLine();

            switch (choice)
            {
                #region MainApp
                case "1":
                    Console.WriteLine("Enter name");
                    string personToLoginName = Console.ReadLine();
                    currentPerson = null;
                    currentPerson = people.FirstOrDefault(e => e.Name == personToLoginName);
                    if (currentPerson is null)
                    {
                        Utils.WriteAndWait("User not found");
                        break;
                    }

                    Console.WriteLine($"Logged at {currentPerson.Name}");
                    Console.Clear();
                    while (currentPerson is not null)
                    {
                        Console.WriteLine("\n1. Add event");
                        Console.WriteLine("2. Display events");
                        Console.WriteLine("3. Integrate my callendar with another user");
                        Console.WriteLine("6. Logout");
                        var userChoise = Console.ReadLine();
                        switch (userChoise)
                        {
                            case "1":
                                Console.WriteLine("Enter event type");
                                Console.WriteLine("1. Metting");
                                Console.WriteLine("2. Task");
                                string eventType = Console.ReadLine();
                                switch (eventType)
                                {
                                    case "1":
                                        Utils.AddMeeting(ref currentPerson, ref tags);
                                        break;

                                    case "2":
                                        Utils.AddTask(ref currentPerson, ref tags);
                                        break;
                                }

                                break;
                            case "2":
                                Utils.DisplayEventsWithIntegration(ref currentPerson, ref people);
                                break;
                            case "3":
                                Utils.IntegrateCalendar(ref currentPerson, ref people);
                                break;
                            case "6":
                                currentPerson = null;
                                Utils.WriteAndWait("Logged out");
                                break;
                        }
                        Console.Clear();
                    }

                    break;
                #endregion
                #region Configs
                case "2":
                    Utils.AddPerson(ref people);
                    Utils.WriteAndWait("Person has been added");
                    break;
                case "3":
                    foreach (var person in people)
                    {
                        person.DisplayDetails();
                    }
                    Utils.WriteAndWait(null);
                    break;
                case "4":
                    Utils.AddTag(ref tags);
                    break;
                case "5":
                    Utils.DisplayTags(tags);
                    break;
                default:
                    Console.WriteLine("Invalid Choice. Try Again.");
                    Utils.WriteAndWait(null);
                    break;
                    #endregion
            }
            Console.Clear();
        }
    }
}

