﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
//using Features.Linq;

namespace Features
{
    class Program
    {
        private static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (a, b) =>
            {
                int temp = a + b;
                return temp;
            };
            Action<int> write = x => Console.WriteLine(x);

            Console.WriteLine(square(3));
            write(square(add(3, 5)));

            var developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Scott" },
                new Employee { Id = 2, Name = "Chris" }
            };

            var sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Alex" }
            };

            var query1 = developers
                .Where(e => e.Name.Length == 5)
                .OrderBy(e => e.Name);

            var query2 = from developer in developers
                where developer.Name.Length == 5
                orderby developer.Name
                select developer;

            // => is read as 'goes to'
            foreach (var employee in query2)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
