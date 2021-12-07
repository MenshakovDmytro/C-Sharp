using menshakov01;
using System;
using System.Linq;

namespace menshakov06
{
    public static class StudentExtension
    {
        delegate int IsEqual(Student[] student);

        /// <summary>
        /// Method that counts chosen average value of a given collection
        /// </summary>
        /// <returns>Returns average value of a chosen field</returns>
        public static int CountAverage(this Student[] _students)
        {
            IsEqual func = null;
            Console.WriteLine("Count avg age or academic performance:");
            Console.WriteLine("1) Age");
            Console.WriteLine("2) Performance");
            var input = Console.ReadLine();
            if (input == "Age")
            {
                func = CountAvgAge;
            }
            else if (input == "Performance")
            {
                func = CountAvgPerformance;
            }
            else
            {
                Console.WriteLine("Invalid option");
                return -1;
            }

            Console.WriteLine("Enter criteria of the counting:");
            Console.WriteLine("1) group index");
            Console.WriteLine("2) specialty");
            Console.WriteLine("3) faculty\n");
            Student[] students = null;
            input = Console.ReadLine();
            switch (input)
            {
                case "group index":
                    Console.WriteLine("Write group index:");
                    input = Console.ReadLine();
                    students = _students.Where(x => x.GroupIndex.Equals(Convert.ToChar(input))).ToArray();
                    break;
                case "specialty":
                    Console.WriteLine("Write specialty:");
                    input = Console.ReadLine();
                    students = _students.Where(x => x.Specialty.Equals(input)).ToArray();
                    break;
                case "faculty":
                    Console.WriteLine("Write faculty:");
                    input = Console.ReadLine();
                    students = _students.Where(x => x.Faculty.Equals(input)).ToArray();
                    break;
                default:
                    input = string.Empty;
                    Console.WriteLine("Invalid option\n");
                    break;
            }

            return func(students);
        }

        /// <summary>
        /// Method that counts average students` age of a given collection
        /// </summary>
        /// <param name="students"></param>
        /// <returns>Returns average value of an age field</returns>
        private static int CountAvgAge(Student[] students)
        {
            var count = 0;

            foreach (var student in students)
            {
                count += DateTime.Now.Year - student.DateOfBirth.Year;
            }

            return count / students.Length;
        }

        /// <summary>
        /// Method that counts average students` performance of a given collection
        /// </summary>
        /// <param name="students"></param>
        /// <returns>Returns average value of an performance field</returns>
        private static int CountAvgPerformance(Student[] students)
        {
            var count = 0;

            foreach (var student in students)
            {
                count += student.AcademicPerformance;
            }

            return count / students.Length;
        }
    }
}
