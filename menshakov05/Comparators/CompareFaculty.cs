using menshakov01;
using System.Collections;

namespace menshakov05.Comparators
{
    /// <summary>
    /// Class CompareFaculty
    /// class that implements IComparer interface
    /// for the faculty of a student
    /// </summary>
    public class CompareFaculty : IComparer
    {
        public int Compare(object x, object y)
        {
            var student = (Student)x;
            var data = (string)y;

            return student.Faculty.CompareTo(data);
        }
    }
}