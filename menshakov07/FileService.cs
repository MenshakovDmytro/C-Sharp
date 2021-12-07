using menshakov01;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace menshakov07
{
    public class FileService
    {
        /// <summary>
        /// Method that writes students' data to JSON file
        /// </summary>
        public void WriteToFile(Student[] students)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));

            try
            {
                using (var file = new FileStream("students.json", FileMode.Create))
                {
                    try
                    {
                        jsonFormatter.WriteObject(file, students);
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
        public void ReadFromFile(Student[] students)
        {
            if (students != null)
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));

                try
                {
                    using (var file = new FileStream("students.json", FileMode.Open))
                    {
                        try
                        {
                            students = jsonFormatter.ReadObject(file) as Student[];
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
    }
}