using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modul11.Task2
{
    public class Person : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(Name);
                    writer.Write(Age);
                }
                info.AddValue("PersonData", stream.ToArray());
            }
        }

        protected Person(SerializationInfo info, StreamingContext context)
        {
            byte[] data = (byte[])info.GetValue("PersonData", typeof(byte[]));
            using (var stream = new MemoryStream(data))
            {
                using (var reader = new BinaryReader(stream))
                {
                    Name = reader.ReadString();
                    Age = reader.ReadInt32();
                }
            }
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Age);
        }

        public static Person Deserialize(BinaryReader reader)
        {
            string name = reader.ReadString();
            int age = reader.ReadInt32();
            return new Person(name, age);
        }
    }
}
