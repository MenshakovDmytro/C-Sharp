using System;
using System.Collections;
using System.Linq;
using menshakov01;

namespace menshakov07
{
    public static class DataProcessing
    {
        delegate int IsEqual(Student[] student);

        /// <summary>
        /// Method that finds student in collection
        /// </summary>
        /// <param name="student"></param>
        /// <returns>If such student exists returns it otherwise null</returns>
        public static Student Find(this Student[] students, Student student)
        {
            for (var i = 0; i < students.Length; i++)
            {
                if (students[i].Equals(student))
                {
                    return students[i];
                }
            }

            return null;
        }

        public static void Sort(this Student[] students, IComparer comparer)
        {
            Array.Sort(students, comparer);
        }

        /// <summary>
        /// Method that allows to edit data of chosen student
        /// </summary>
        /// <param name="student"></param>
        public static void EditData(this Student[] students, Student student)
        {
            var pos = -1;

            for (var i = 0; i < students.Length; i++)
            {
                if (students[i].Equals(student))
                {
                    pos = i;
                    break;
                }
            }

            if (pos != -1)
            {
                Console.WriteLine("Enter what field you want to edit:\n1) Name\n2) Surname\n3) Patronymic\n4) Date of birth\n5) Date of admission\n" +
                    "6) Group index\n7) Faculty\n8) Specialty\n9) Academic performance\n");
                var option = Console.ReadLine();
                try
                {
                    switch (option)
                    {
                        case "Name":
                            students[pos].Name = Console.ReadLine();
                            break;
                        case "Surname":
                            students[pos].Surname = Console.ReadLine();
                            break;
                        case "Patronymic":
                            students[pos].Patronymic = Console.ReadLine();
                            break;
                        case "Date of birth":
                            students[pos].DateOfBirth = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Date of admission":
                            students[pos].DateOfAdmission = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Group index":
                            students[pos].GroupIndex = char.Parse(Console.ReadLine());
                            break;
                        case "Faculty":
                            students[pos].Faculty = Console.ReadLine();
                            break;
                        case "Specialty":
                            students[pos].Specialty = Console.ReadLine();
                            break;
                        case "Academic performance":
                            students[pos].AcademicPerformance = int.Parse(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Invalid option\n");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("There is no such student in collection\n");
            }
        }

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

            var averagePerformance = (from student in students
                         select student.AcademicPerformance)
                        .Average();

            return (int)averagePerformance;
        }
    }
}