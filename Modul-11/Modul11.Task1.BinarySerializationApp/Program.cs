using System.Runtime.Serialization;


namespace Modul11.Task1.BinarySerializationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department dept = new Department
            {
                DepartmentName = "IT_Department_Binary",
                Employees = new List<Employee>
            {
                new Employee { EmployeeName = "Ulugbek Toshtemirov" },
                new Employee { EmployeeName = "Yusupov Xondamir" }
            }
            };

            string filePath = @"C:\Users\Ulugbek_Toshtemirov\Desktop\.NET Mentoring\Epam_NET_Mentoring\Modul-11\Modul11.Task1.BinarySerializationApp\department.bin";

            // Serialize
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, System.Text.Encoding.UTF8, false))
                {
                    dept.WriteToBinaryWriter(writer);
                }
            }

            // Deserialize
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, System.Text.Encoding.UTF8, false))
                {
                    Department deserializedDept = Department.ReadFromBinaryReader(reader);
                    Console.WriteLine($"Department: {deserializedDept.DepartmentName}");
                    foreach (var emp in deserializedDept.Employees)
                    {
                        Console.WriteLine($"Employee: {emp.EmployeeName}");
                    }
                }
            }
        }
    }
}
