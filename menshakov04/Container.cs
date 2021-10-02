using System;
using System.Collections;
using menshakov01;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace menshakov04
{
    /// <summary>
    /// Class Container
    /// class that implements class container
    /// for collection of students
    /// </summary>
    public sealed class Container : IEnumerable
    {
        /// <summary>
        /// Private field students
        /// </summary>
        private Student[] _students;

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="students"></param>
        public Container(Student[] students)
        {
            _students = new Student[students.Length];

            for (int i = 0; i < students.Length; i++)
            {
                _students[i] = students[i];
            }
        }

        /// <summary>
        /// Method that adds student to collection
        /// </summary>
        /// <param name="student"></param>
        public void Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student is null");
            }

            var newArr = new Student[_students.Length + 1];

            for (int i = 0; i < _students.Length; i++)
            {
                newArr[i] = _students[i];
            }

            newArr[newArr.Length - 1] = student;
            _students = newArr;
        }

        /// <summary>
        /// Method that removes student from collection
        /// </summary>
        /// <param name="student"></param>
        /// <returns>True if student was removed otherwise false</returns>
        public bool Remove(Student student)
        {
            if (student == null)
            {
                return false;
            }

            int pos = -1;

            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                return false;
            }

            var newArr = new Student[_students.Length - 1];

            for (int i = 0; i < pos; i++)
            {
                newArr[i] = _students[i];
            }
            for (int i = pos + 1; i < _students.Length; i++)
            {
                newArr[i - 1] = _students[i];
            }

            _students = newArr;
            return true;
        }

        /// <summary>
        /// Method that finds student in collection
        /// </summary>
        /// <param name="student"></param>
        /// <returns>If such student exists returns it otherwise null</returns>
        public Student Find(Student student)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    return _students[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Method that writes students' data to JSON file
        /// </summary>
        public void WriteToFile()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));

            try
            {
                using (var file = new FileStream("students.json", FileMode.Create))
                {
                    try
                    {
                        jsonFormatter.WriteObject(file, _students);
                        Console.WriteLine("Data were successfully written to file\n");
                    }
                    catch (System.Runtime.Serialization.SerializationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Method that reads students' data from JSON file
        /// </summary>
        public void ReadFromFile()
        {
            if (_students != null)
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));

                try
                {
                    using (var file = new FileStream("students.json", FileMode.Open))
                    {
                        try
                        {
                            _students = jsonFormatter.ReadObject(file) as Student[];
                            Console.WriteLine("Data were successfully read from file\n");
                        }
                        catch (System.Runtime.Serialization.SerializationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("There are no students in container\n");
            }
        }

        /// <summary>
        /// Method that allows to edit data of chosen student
        /// </summary>
        /// <param name="student"></param>
        public void EditData(Student student)
        {
            int pos = -1;

            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    pos = i;
                    break;
                }
            }

            if (pos != -1)
            {
                Console.WriteLine("Enter what field you want to edit:\n1) Name\n2) Surname\n3) Patronymic\n4) Date of birth\n5) Date of admission\n" +
                    "6) Group index\n7) Faculty\n8) Specialty\n9) Academic performance\n");
                string option = Console.ReadLine();
                try
                {
                    switch (option)
                    {
                        case "Name":
                            _students[pos].Name = Console.ReadLine();
                            break;
                        case "Surname":
                            _students[pos].Surname = Console.ReadLine();
                            break;
                        case "Patronymic":
                            _students[pos].Patronymic = Console.ReadLine();
                            break;
                        case "Date of birth":
                            _students[pos].DateOfBirth = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Date of admission":
                            _students[pos].DateOfAdmission = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Group index":
                            _students[pos].GroupIndex = Char.Parse(Console.ReadLine());
                            break;
                        case "Faculty":
                            _students[pos].Faculty = Console.ReadLine();
                            break;
                        case "Specialty":
                            _students[pos].Specialty = Console.ReadLine();
                            break;
                        case "Academic performance":
                            _students[pos].AcademicPerformance = Int32.Parse(Console.ReadLine());
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
        /// Method that prints chosen data about student
        /// </summary>
        /// <param name="student"></param>
        public void ShowData(Student student)
        {
            int pos = -1;

            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    pos = i;
                    break;
                }
            }

            if (pos != -1)
            {
                var dataForPrint = new StringBuilder();
                Console.WriteLine("Enter what data you want to get:\n1) Group\n2) Course\n3) Age\n");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "Group":
                        dataForPrint.AppendFormat("\nFaculty: {0}\nSpecialty: {1}\nDate of admission: {2}\nGroup index: {3}", student.Faculty,
                            student.Specialty, student.DateOfAdmission.Year, student.GroupIndex);
                        Console.WriteLine(dataForPrint.ToString());
                        dataForPrint.Clear();
                        break;
                    case "Course":
                        dataForPrint.AppendFormat("\nCourse: {0}\nSemester: {1}\n", (DateTime.Now.Year - student.DateOfAdmission.Year) + 1,
                            Math.Ceiling((double)((12 * (DateTime.Now.Year - student.DateOfAdmission.Year) + DateTime.Now.Month - student.DateOfAdmission.Month)
                           - 2 * (DateTime.Now.Year - student.DateOfAdmission.Year))) / 5);    
                        Console.WriteLine(dataForPrint.ToString());
                        dataForPrint.Clear();
                        break;
                    case "Age":
                        dataForPrint.AppendFormat("\nYears: {0}\nMonth: {1}\nDays: {2}\n", DateTime.Now.Year - student.DateOfBirth.Year, 
                            (Math.Abs(DateTime.Now.Month - student.DateOfBirth.Month)) - 1, DateTime.Now.Day);
                        Console.WriteLine(dataForPrint.ToString());
                        dataForPrint.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid option\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("There is no such student in collection\n");
            }
        }

        /// <summary>
        /// Implemented GetEnumerator method
        /// </summary>
        /// <returns>ContainerEnum</returns>
        public IEnumerator GetEnumerator()
        {
            return new ContainerEnum(_students);
        }
    }

    /// <summary>
    /// Class ContainerEnum
    /// class that implements IEnumerator for student class
    /// </summary>
    public sealed class ContainerEnum : IEnumerator
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
        public ContainerEnum(Student[] students)
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