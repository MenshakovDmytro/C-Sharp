using menshakov01;
using System;
using System.Collections;

namespace menshakov06
{
    /// <summary>
    /// Class ContainerEnum
    /// class that implements IEnumerator for student class
    /// </summary>
    public class ContainerEnumerator : IEnumerator
    {
        /// <summary>
        /// Private fields of a class
        /// </summary>
        private Student[] _students;
        private int _position = -1;

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="students"></param>
        public ContainerEnumerator(Student[] students)
        {
            _students = students;
        }

        /// <summary>
        /// Implemented Current property
        /// </summary>
        public object Current
        {
            get
            {
                try
                {
                    return _students[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Implemented MoveNext method
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            _position++;

            return _position < _students.Length;
        }

        /// <summary>
        /// Implemented Reset method
        /// </summary>
        public void Reset()
        {
            _position = -1;
        }
    }
}