using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeladasautoemelt
{
    internal class TextLine
    {
        public string plate { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Speed { get; set; }
        public TextLine(string line)
        {
            // A sorban az adatok tabulátorral vannak elválasztva
            string[] parts = line.Split("\t");
            if (parts.Length >= 4)
            {
                plate = parts[0];
                Hour = int.Parse(parts[1]);
                Minute = int.Parse(parts[2]);
                Speed = int.Parse(parts[3]);
            }
            else
            {
                throw new ArgumentException("A sor formátuma nem megfelelő: " + line);
            }
        }
    }
}
