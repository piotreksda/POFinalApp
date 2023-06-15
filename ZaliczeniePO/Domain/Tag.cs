using System;
using ZaliczeniePO.Domain.Intefaces;

namespace ZaliczeniePO.Domain
{
    public class Tag: IDisplayable
    {
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }

        public Tag(string name, ConsoleColor color)
        {
            Name = name;
            Color = color;
        }

        public void DisplayDetails()
        {
            Console.BackgroundColor = Color;
            Console.WriteLine($"Tag: Name {Name}, Color {Color}");
            Console.ResetColor();
        }
    }
}

