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
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturer("manufacturers.csv");

            var query = from car in cars
                        group car by car.Manufacturer.ToUpper() 
                            into manufacturer
                        orderby manufacturer.Key
                        select manufacturer;

            var query2 = cars
                .GroupBy(c => c.Manufacturer.ToUpper())
                .OrderBy(g => g.Key);

            foreach (var group in query2)
            {
                Console.WriteLine(group.Key);

                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }
        }

        private static IEnumerable<Car> ProcessCars(string path)
        {
            var query = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .ToCar();

            return query.ToList();
        }

        private static IEnumerable<Manufacturer> ProcessManufacturer(string path)
        {
            var query = File.ReadAllLines(path)
                .Where(line => line.Length > 1)
                .ToManufacturer();

            return query.ToList();
        }
    }
}
