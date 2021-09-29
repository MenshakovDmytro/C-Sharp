using System;

namespace menshakov01
{
    /// <summary>
    /// Class Program
    /// class that creates array of students
    /// and prints it in console
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter student's surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter student's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student's patronymic: ");
            string patronymic = Console.ReadLine();
            Console.WriteLine("Enter student's date of birth: ");
            string dateOfBirth = Console.ReadLine();
            Console.WriteLine("Enter student's date of admission: ");
            string dateOfAdmission = Console.ReadLine();
            Console.WriteLine("Enter student's group index: ");
            string groupIndex = Console.ReadLine();
            Console.WriteLine("Enter student's faculty: ");
            string faculty = Console.ReadLine();
            Console.WriteLine("Enter student's specialty: ");
            string specialty = Console.ReadLine();
            Console.WriteLine("Enter student's academic performance: ");
            string academicPerformance = Console.ReadLine();

            // Creating array of students
            var students = new Student[] { new Student("Bily", "Vadim", "Ivanovich", "12-6-2001", "16-05-2018", 'a', "CIT", "Computer engineering", "100"),
                new Student("Menshakov", "Dmytro", "Olegovich", "16-11-2000", "23-8-2018", 'a', "CIT", "Computer engineering", "90"),
                new Student(name, surname, patronymic, dateOfBirth, dateOfAdmission, Convert.ToChar(groupIndex), faculty, specialty, academicPerformance)};

            // Printing out students' data
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].ToString());
            }
            Console.ReadLine();
        }
    }
}