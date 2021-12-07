using menshakov01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menshakov07
{
    class Program
    {
        static void Main(string[] args)
        {
            var customStudent = new Student("Momot", "Roman", "Evegenievich", DateTime.Parse("10-8-2001"), DateTime.Parse("16-05-2019"), 'b', "CIT", "Computer engineering", 80);
            var students = new Student[] { new Student("Bily", "Vadim", "Ivanovich", DateTime.Parse("12-6-2001"), DateTime.Parse("16-05-2019"), 'a', "CIT", "Computer engineering", 100),
                new Student("Menshakov", "Dmytro", "Olegovich", DateTime.Parse("16-11-2000"), DateTime.Parse("23-8-2019"), 'b', "CIT", "Computer engineering", 90)};
            var list = new Container(students);
            list.Add(customStudent);
            list.Students.CountAverage();
            var query = from student in students
                        where student.GroupIndex == 'b'
                        select student;
            var dataPrintService = new DataPrintService();
            dataPrintService.ShowFormattedData(query.ToArray());
        }
    }
}
