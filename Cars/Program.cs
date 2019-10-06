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

            var query1 = cars.All(c => c.Manufacturer == "Ford");

            Console.WriteLine(cars.Any(c => c.Manufacturer == "Ford"));
            Console.WriteLine(cars.All(c => c.Manufacturer == "Ford"));

            var query2 = from car in cars
                         where car.Manufacturer == "BMW" && car.Year == 2016
                         orderby car.Combined, car.Name
                         select car;
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
