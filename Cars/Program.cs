using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            foreach (var car in cars)
            {
                Console.WriteLine(car.Name);
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            // Query Syntax
            var query1 = from line in File.ReadAllLines(path).Skip(1)
                where line.Length > 1
                select Car.ParseFromCsv(line);

            // Extension Method Syntax
            var query2 = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Car.ParseFromCsv);

            return query1.ToList();
        }
    }
}
