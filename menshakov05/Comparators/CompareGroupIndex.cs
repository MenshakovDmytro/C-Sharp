using menshakov01;
using System;
using System.Collections;

namespace menshakov05.Comparators
{
    /// <summary>
    /// Class CompareGroups
    /// class that implements IComparer interface
    /// for the group of a student
    /// </summary>
    public class CompareGroupIndex : IComparer
    {
        public int Compare(object x, object y)
        {
            var student = (Student)x;
            var criteria = Convert.ToChar(y);

            return student.GroupIndex.CompareTo(criteria);
        }
    }
}