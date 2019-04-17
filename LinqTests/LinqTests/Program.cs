using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTests
{
    class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentArray = new List<Student>{
            new Student() { StudentID = 1, StudentName = "John", Age = 18 },
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 },
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 },
            new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 },
            new Student() { StudentID = 7, StudentName = "Rob",Age = 19  },
        };
            IEnumerable<string> names = new List<string>()
            {
                "Dario",
                "Vito",
                "Antonio",
                "Carillo",
                "Vito",
            };

            var lessNames = names.Distinct();



            //IEnumerable<Student> students = new List<Student>();

            //    var studentsGroupedByAge = studentArray.OrderBy(s => s.Age).ToLookup(s => s.Age);

            //    foreach (var ageGroup in studentsGroupedByAge)
            //    { 
            //        Console.WriteLine($"Age: {ageGroup.Key}");
            //        foreach (Student s in ageGroup)
            //    {
            //        Console.WriteLine($"    Name:{s.StudentName}");
            //    }
            //    }
            //        Func<Student, bool> hasMoreThan19 = s => s.Age > 19;

            //   bool = hasMoreThan19(studentArray[0]);

            //      students = studentArray.Where(hasMoreThan19);

            //students = studentArray.OrderByDescending(s => s.StudentName).ThenByDescending(s =>s.Age);

            var Steve = studentArray.Concat(studentArray);

        //foreach (var s in selectResult)
        //{
        //    Console.WriteLine($"Name: {s.Name}, Age Incremented {s.AgeI}");
        //}

            Console.ReadKey();
        }
    }
}
