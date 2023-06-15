using System;
namespace ZaliczeniePO.Domain
{
    public class Meeting : Event
    {
        public string Location { get; set; }
        public List<Person> Attendees { get; set; }
        public Meeting()
        {
            Attendees = new List<Person>();
        }
        public override void DisplayDetails()
        {
            Console.BackgroundColor = this.GetTag().Color;
            Console.WriteLine($"Meeting: {Title} @ {Location} on {Date}");
            Console.ResetColor();
            Console.WriteLine("Attendees: ");
            foreach (var attendee in Attendees)
            {
                Console.WriteLine(attendee.Name);
            }
        }
        public void InvitePerson(Person person)
        {
            Attendees.Add(person);
            person.Calendar.AddEvent(this);
        }
    }
}

