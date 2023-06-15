using System;
using ZaliczeniePO.Domain.Intefaces;

namespace ZaliczeniePO.Domain
{
    public abstract class Event: IDisplayable
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        
        private Tag _tag { get; set; }

        

        public void SetTag(Tag tag)
        {
            _tag = tag;
        }
        public Tag GetTag() => _tag;

        public abstract void DisplayDetails();

        
    }
}

