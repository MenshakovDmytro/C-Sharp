using System;
using System.Runtime.Serialization;

namespace menshakov01
{
    /// <summary>
    /// Class Student
    /// class that models student
    /// contains student's fields and properties
    /// </summary>
    [DataContract]
    public sealed class Student
    {
        /// <summary>
        /// Private fields of a class
        /// </summary>
        private string _name;
        private string _surname;
        private string _patronymic;
        private DateTime _dateOfBirth;
        private DateTime _dateOfAdmission;
        private char _groupIndex;
        private string _faculty;
        private string _specialty;
        private int _academicPerformance;

       /// <summary>
       /// Constructor with 9 parameters
       /// </summary>
       /// <param name="surname"></param>
       /// <param name="name"></param>
       /// <param name="patronymic"></param>
       /// <param name="dateOfBirth"></param>
       /// <param name="dateOfAdmission"></param>
       /// <param name="groupIndex"></param>
       /// <param name="faculty"></param>
       /// <param name="specialty"></param>
       /// <param name="academicPerformance"></param>
        public Student(string surname, string name, string patronymic, DateTime dateOfBirth, DateTime dateOfAdmission, char groupIndex,
            string faculty, string specialty, int academicPerformance)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            DateOfAdmission = dateOfAdmission;
            GroupIndex = groupIndex;
            Faculty = faculty;
            Specialty = specialty;
            AcademicPerformance = academicPerformance;
        }

        /// <summary>
        /// Public property Name
        /// </summary>
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value.Length < 2 && value.Length > 10)
                {
                    Console.WriteLine("You've entered wrong name\n");
                }
                else
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Public property Surname
        /// </summary>

        [DataMember]
        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("You've entered wrong surname\n");
                }
                else
                {
                    _surname = value;
                }
            }
        }

        /// <summary>
        /// Public property Patronymic
        /// </summary>

        [DataMember]
        public string Patronymic
        {
            get
            {
                return _patronymic;
            }

            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("You've entered wrong patronymic\n");
                }
                else
                {
                    _patronymic = value;
                }
            }
        }

        /// <summary>
        /// Public property DateOfBirth
        /// </summary>

        [DataMember]
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                if (value < new DateTime(2000, 1, 1) || value > DateTime.Today)
                {
                    Console.WriteLine("You've entered wrong date of birth\n");
                }
                _dateOfBirth = value;
            }
        }

        /// <summary>
        /// Public property DateOfAdmission
        /// </summary>

        [DataMember]
        public DateTime DateOfAdmission
        {
            get
            {
                return _dateOfAdmission;
            }

            set
            {
                if (value < new DateTime(2015, 1, 1) || value > DateTime.Today)
                {
                    Console.WriteLine("You've entered wrong date of admission\n");
                }
                _dateOfAdmission = value;
            }
        }

        /// <summary>
        /// Public property GroupIndex
        /// </summary>

        [DataMember]
        public char GroupIndex
        {
            get
            {
                return _groupIndex;
            }

            set
            {
                if (value < 97 || value > 122)
                {
                    Console.WriteLine("You've entered wrong group index\n");
                }
                else
                {
                    _groupIndex = value;
                }
            }
        }

        /// <summary>
        /// Public property Faculty
        /// </summary>

        [DataMember]
        public string Faculty
        {
            get
            {
                return _faculty;
            }

            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("You've entered wrong faculty\n");
                }
                else
                {
                    _faculty = value;
                }
            }
        }

        /// <summary>
        /// Public property Specialty
        /// </summary>

        [DataMember]
        public string Specialty
        {
            get
            {
                return _specialty;
            }

            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("You've entered wrong specialty\n");
                }
                else
                {
                    _specialty = value;
                }
            }
        }

        /// <summary>
        /// Public property AcademicPerformance
        /// </summary>

        [DataMember]
        public int AcademicPerformance
        {
            get
            {
                return _academicPerformance;
            }

            set
            {
                if (_academicPerformance < 0 || _academicPerformance > 100)
                {
                    Console.WriteLine("You've entered wrong academic performance\n");
                }
                _academicPerformance = value;
            }
        }

        /// <summary>
        /// ToString method overriding
        /// </summary>
        /// <returns>Full data about student</returns>
        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nPatronymic: {Patronymic}\nDate of birth: {DateOfBirth}\nDate of admission: {DateOfAdmission}\n" +
                $"Group index: {GroupIndex}\nFaculty: {Faculty}\nSpecialty: {Specialty}\nAcademic performance: {AcademicPerformance}%\n";
        }

        /// <summary>
        /// Equals method overriding
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>If objects are equal returns true otherwise false</returns>
        public override bool Equals(object obj)
        {
            Student other = obj as Student;
            return other != null && (Name, Surname, Patronymic).Equals((other.Name, other.Surname, other.Patronymic)); 
        }

        /// <summary>
        /// GetHashCode method overriding
        /// </summary>
        /// <returns>Hashcode of an object</returns>
        public override int GetHashCode()
        {
            return (Name, Surname, Patronymic).GetHashCode();
        }
    }
}