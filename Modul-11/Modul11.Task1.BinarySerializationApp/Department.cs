using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul11.Task1.BinarySerializationApp
{
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public void WriteToBinaryWriter(BinaryWriter writer)
        {
            writer.Write(DepartmentName);
            writer.Write(Employees.Count);
            foreach (var employee in Employees)
            {
                employee.WriteToBinaryWriter(writer);
            }
        }

        public static Department ReadFromBinaryReader(BinaryReader reader)
        {
            var department = new Department
            {
                DepartmentName = reader.ReadString()
            };

            int employeeCount = reader.ReadInt32();
            for (int i = 0; i < employeeCount; i++)
            {
                department.Employees.Add(Employee.ReadFromBinaryReader(reader));
            }

            return department;
        }
    }

}
