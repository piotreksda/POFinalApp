using System;
using ZaliczeniePO.Domain.Intefaces;

namespace ZaliczeniePO.Domain
{
    public class Person: IDisplayable
    {
        public string Name { get; set; }
        public Calendar Calendar { get; set; }

        public Person(string name)
        {
            Name = name;
            Calendar = new Calendar();
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"{Name}");
        }
        //public void ConfirmInvitation(Event ev)
        //{
        //    if (Calendar.Events.Contains(ev))
        //    {
        //        ev.ConfirmedAttendees.Add(this);
        //    }
        //}
    }
}

