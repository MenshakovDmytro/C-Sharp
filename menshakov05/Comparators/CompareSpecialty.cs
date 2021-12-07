using menshakov01;
using System.Collections;

namespace menshakov05.Comparators
{
    /// <summary>
    /// Class CompareSpecialty
    /// class that implements IComparer interface
    /// for the specialty of a student
    /// </summary>
    public class CompareSpecialty : IComparer
    {
        public int Compare(object x, object y)
        {
            var student = (Student)x;
            var data = (string)y;

            return student.Specialty.CompareTo(data);
        }
    }
}