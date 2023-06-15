using System;
namespace ZaliczeniePO.Domain
{
    public class Calendar
    {
        private List<Event> _events = new List<Event>();
        public List<Event> Events { get => _events;}
        public void AddEvent(Event ev)
        {
            _events.Add(ev);
        }

        public void DisplayEvents()
        {
            foreach (var ev in _events)
            {
                ev.DisplayDetails();
            }
        }
        
        public void IntegrateWith(Calendar otherCalendar)
        {
            foreach (var ev in otherCalendar._events)
            {
                if (!_events.Contains(ev))
                {
                    _events.Add(ev);
                }
            }
        }
    }
}

