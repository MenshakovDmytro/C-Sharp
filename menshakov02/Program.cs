using System;
using menshakov01;

namespace menshakov02
{
    class Program
    {
        static void Main(string[] args)
        {
            var customStudent = new Student("Momot", "Roman", "Evegenievich", "10-8-2001", "16-05-2018", 'a', "CIT", "Computer engineering", "80");
            var students = new Student[] { new Student("Bily", "Vadim", "Ivanovich", "12-6-2001", "16-05-2018", 'a', "CIT", "Computer engineering", "100"),
                new Student("Menshakov", "Dmytro", "Olegovich", "16-11-2000", "23-8-2018", 'a', "CIT", "Computer engineering", "90")};
            var list = new Container(students);

            list.Add(customStudent);
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            list.Remove(new Student("Menshakov", "Dmytro", "Olegovich", "16-11-2000", "23-8-2018", 'a', "CIT", "Computer engineering", "90"));
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            var stud = list.Find(customStudent);

            Console.ReadLine();
        }
    }
}