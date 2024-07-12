using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Modul11.Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Ulugbek Toshtemirov", 30);
            string filePath = @"C:\Users\Ulugbek_Toshtemirov\Desktop\.NET Mentoring\Epam_NET_Mentoring\Modul-11\Modul11.Task2\person.bin";

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    person.Serialize(writer);
                }
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Person deserializedPerson = Person.Deserialize(reader);
                    Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
                }
            }
        }
    }
}
