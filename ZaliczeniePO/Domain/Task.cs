using System;
namespace ZaliczeniePO.Domain
{
    public class Task : Event
    {
        public string Description { get; set; }

        public override void DisplayDetails()
        {
            Console.BackgroundColor = this.GetTag().Color;
            Console.WriteLine($"Task: {Title} - {Description} on {Date}");
            Console.ResetColor();
        }
    }
}

