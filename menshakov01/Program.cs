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
            /*Console.WriteLine("Enter student's surname: ");
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
            string academicPerformance = Console.ReadLine();*/

            // Creating array of students
            var students = new Student[] { new Student("Bily", "Vadim", "Ivanovich", DateTime.Parse("12-6-2001"), DateTime.Parse("16-05-2019"), 'a', "CIT", "123 - Computer engineering", 100),
                new Student("Menshakov", "Dmytro", "Olegovich", DateTime.Parse("16-11-2000"), DateTime.Parse("23-8-2019"), 'a', "CIT", "123 - Computer engineering", 90)/*,
                new Student(name, surname, patronymic, DateTime.Parse(dateOfBirth), DateTime.Parse(dateOfAdmission), Convert.ToChar(groupIndex), faculty, specialty, Int32.Parse(academicPerformance))*/};

            // Printing out students' data
            for (var i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].ToString());
            }
            Console.ReadLine();
        }
    }
}