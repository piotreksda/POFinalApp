using System;
using ZaliczeniePO.Domain;

namespace ZaliczeniePO.Tools
{
    public static class Utils
    {
        public static void WriteAndWait(string? message)
        {
            Console.WriteLine((message is not null ? message + " " : "") + "(Press enter to continue)");
            Console.ReadLine();
        }
        public static void AddPerson(ref List<Person> people)
        {
            Console.WriteLine("Enter person name ");
            string personName = Console.ReadLine();
            people.Add(new Person(personName));
        }
        public static void AddTag(ref List<Tag> tags)
        {
            Console.WriteLine("Enter tag name");
            string tagName = Console.ReadLine();
            Console.WriteLine("Choose color");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Magenta");
            Console.WriteLine("3. Blue");
            Console.WriteLine("4. Green");
            Console.WriteLine("else => Black");
            string tagColorChoose = Console.ReadLine();
            ConsoleColor consoleColor;
            switch (tagColorChoose)
            {
                case "1":
                    consoleColor = ConsoleColor.Red;
                    break;
                case "2":
                    consoleColor = ConsoleColor.Magenta;
                    break;
                case "3":
                    consoleColor = ConsoleColor.Blue;
                    break;
                case "4":
                    consoleColor = ConsoleColor.Green;
                    break;
                default:
                    Console.WriteLine("white has been choosen becouse enter bad value");
                    consoleColor = ConsoleColor.Black;
                    break;
            }
            Tag tag = new Tag(tagName, consoleColor);
            tags.Add(tag);
            Console.BackgroundColor = consoleColor;
            Utils.WriteAndWait("Tag added");
            Console.ResetColor();
        }
        public static void DisplayTags(List<Tag> tags)
        {
            foreach (var tagItem in tags)
            {
                tagItem.DisplayDetails();
            }
            Utils.WriteAndWait(null);
        }
        public static void AddTask(ref Person currentPerson, ref List<Tag> tags)
        {
            Console.WriteLine("Enter Task Title: ");
            string taskTitle = Console.ReadLine();
            Console.WriteLine("Enter Task Description: ");
            string taskDescription = Console.ReadLine();
            Console.WriteLine("Enter Task Date (yyyy-MM-dd): ");
            DateTime taskDate = DateTime.Parse(Console.ReadLine());
            Domain.Task task = new Domain.Task { Title = taskTitle, Description = taskDescription, Date = taskDate };
            Console.WriteLine("Do you want to add tag? y/n");
            var taskTagNY = Console.ReadLine();
            if (taskTagNY != "y")
                task.SetTag(tags.First(e => e.Name == "default"));
            else
            {
                foreach (var tagItem in tags)
                {
                    tagItem.DisplayDetails();
                }
                Console.WriteLine("Enter tag name");
                var taskTagToChoose = Console.ReadLine();
                var taskTagToChooseObj = tags.FirstOrDefault(e => e.Name == taskTagToChoose);
                if (taskTagToChooseObj is null)
                    task.SetTag(tags.First(e => e.Name == "default"));
                else
                    task.SetTag(taskTagToChooseObj);
            }
            currentPerson.Calendar.AddEvent(task);
            Utils.WriteAndWait("Task added press");
        }
        public static void AddMeeting(ref Person currentPerson, ref List<Tag> tags)
        {
            Console.WriteLine("Enter Meeting Title: ");
            string meetingTitle = Console.ReadLine();
            Console.WriteLine("Enter Meeting Location: ");
            string meetingLocation = Console.ReadLine();
            Console.WriteLine("Enter Meeting Date (yyyy-MM-dd): ");
            DateTime meetingDate = DateTime.Parse(Console.ReadLine());
            Meeting meeting = new Meeting { Title = meetingTitle, Location = meetingLocation, Date = meetingDate };
            Console.WriteLine("Do you want to add tag? y/n");
            var mettingTagNY = Console.ReadLine();
            if (mettingTagNY != "y")
                meeting.SetTag(tags.First(e => e.Name == "default"));
            else
            {
                foreach (var tagItem in tags)
                {
                    tagItem.DisplayDetails();
                }
                Console.WriteLine("Enter tag name");
                var mettingTagToChoose = Console.ReadLine();
                var mettingTagToChooseObj = tags.FirstOrDefault(e => e.Name == mettingTagToChoose);
                if (mettingTagToChooseObj is null)
                    meeting.SetTag(tags.First(e => e.Name == "default"));
                else
                    meeting.SetTag(mettingTagToChooseObj);
            }
            currentPerson.Calendar.AddEvent(meeting);
            Utils.WriteAndWait("Metting added");
        }
        public static void IntegrateCalendar(ref Person currentPerson, ref List<Person> people)
        {
            Console.WriteLine("Enter user name");
            string personToIntegrateCalendar = Console.ReadLine();
            Person personToIntegrateCalendarObj = people.First(e => e.Name == personToIntegrateCalendar);
            if (personToIntegrateCalendarObj is null)
            {
                Utils.WriteAndWait("User not found stop! (enter to continue)");
                return;
            }
            currentPerson.Calendar.IntegrateWith(personToIntegrateCalendarObj.Calendar);
            Utils.WriteAndWait("Callendar integrated");
        }
        public static void DisplayEventsWithIntegration(ref Person currentPerson, ref List<Person> people)
        {
            currentPerson.Calendar.DisplayEvents();

            Console.WriteLine("Do you want to do something about any of the events? (y/n)");
            var yn = Console.ReadLine();
            if (yn != "y")
            {
                Utils.WriteAndWait(null);
                return;
            }
            Console.WriteLine("Choose event by name");
            var eventName = Console.ReadLine();
            var choosenEvent = currentPerson.Calendar.Events.FirstOrDefault(e => e.Title == eventName);
            if (choosenEvent is null)
            {
                Utils.WriteAndWait("Failed to select an event");
                return;
                Console.WriteLine("1. Add a another person to the event (only for meetings)");
                var actionChoose = Console.ReadLine();
                switch (actionChoose)
                {
                    case "1":
                        if (choosenEvent is Meeting meeting)
                        {
                            Console.WriteLine("Enter a person name");
                            var enteredPersonName = Console.ReadLine();
                            var enteredPerson = people.FirstOrDefault(e => e.Name == enteredPersonName);
                            if (enteredPerson is null)
                            {
                                Utils.WriteAndWait("Failed to select a person");
                                break;
                            }
                            meeting.InvitePerson(enteredPerson);
                            Utils.WriteAndWait($"Event has been added to {enteredPerson.Name}s calendar");
                        }
                        else
                            Utils.WriteAndWait($"You have to pick metting to invite someone");
                        break;
                    default:
                        Utils.WriteAndWait("Bad choose");
                        break;
                }
            }
        }
    }
}

