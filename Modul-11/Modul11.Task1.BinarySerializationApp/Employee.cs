using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul11.Task1.BinarySerializationApp
{
    public class Employee
    {
        public string EmployeeName { get; set; }

        public void WriteToBinaryWriter(BinaryWriter writer)
        {
            writer.Write(EmployeeName);
        }

        public static Employee ReadFromBinaryReader(BinaryReader reader)
        {
            return new Employee
            {
                EmployeeName = reader.ReadString()
            };
        }
    }

}
