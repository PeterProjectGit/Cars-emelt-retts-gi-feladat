using System.IO;
namespace jeladasautoemelt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "./jeladas.txt";
            string[] row = File.ReadAllLines(path);
            List<TextLine> content = new List<TextLine>();
            for (int i = 0; i < row.Length; i++)
            {
                TextLine line = new TextLine(row[i]);
                content.Add(line);
            }
            Console.WriteLine(content.Count);
            
            //2.
            Console.WriteLine($"2. feladat: \nAz utolsó jeladás időpontja {content[^1].Hour}:{content[^1].Minute}, a jármű rendszáma: {content[^1].plate}");

            //3.
            TextLine firstCar = content[0];
            Console.WriteLine($"Az első jármű adatai: {firstCar.plate}");
            Console.Write("Jeladásainak időpontjai: ");
            foreach (TextLine car in content)
            {
                if (firstCar.plate == car.plate)
                {
                    Console.Write($"{car.Hour}:{car.Minute}");
                }
            }
            //4.
            Console.WriteLine("4. feladat");
            Console.Write("Kérem, adja meg az órát: ");
            int hourInput = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kérem, adja meg az percet: ");
            int minuteInput = Convert.ToInt32(Console.ReadLine());
            List<TextLine> cartimes = new List<TextLine>();

            foreach (TextLine car in content)
            {
                if (car.Hour == hourInput && car.Minute == minuteInput)
                {
                    cartimes.Add(car);
                }
            }
            Console.WriteLine($"A jeladások száma: {cartimes.Count}");

            //5.
            List<TextLine> fastestCars = new List<TextLine>();
            int lastSpeed = 0;
            Console.WriteLine("5.feladat: ");
            foreach (TextLine car in content)
            {
                if (car.Speed > lastSpeed)
                {
                    fastestCars.Clear();
                    fastestCars.Add(car);
                    lastSpeed = car.Speed;        
                }
                if (car.Speed == lastSpeed)
                {
                    fastestCars.Add(car);
                }
            }
            Console.WriteLine($"A legnagyobb sebesség {fastestCars[0].Speed}km/h");
            Console.Write($"A járművek: ");
            foreach (TextLine car in fastestCars)
            {
                Console.Write($"{car.plate} ");
            }
            //6
            Console.WriteLine("6. feladat: ");
            Console.Write("Kérem adja meg a rendszámot: ");
            string plateInput = Console.ReadLine();

            int currenttime = 0;
            int carspeed = 0;
            double distance = 0.0;
            // Assume currenttime and carspeed have been set for the first record
            foreach (TextLine car in content)
            {
                if (car.plate == plateInput)
                {
                    int newTime = car.Hour * 60 + car.Minute;
                    if (newTime > currenttime)
                    {
                        distance += ((newTime - currenttime) / 60.0) * carspeed;
                    }
                    currenttime = newTime;
                    carspeed = car.Speed;
                    
                    Console.WriteLine($"{car.Hour:D2}:{car.Minute:D2} - {distance:F1} km");
                }
            }

            
            


            
            
            

        }
    }
}
