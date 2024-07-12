using System.Xml.Serialization;

namespace Modul11.Task1.XmlSerializationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department dept = new Department
            {
                DepartmentName = "IT_Department_XML",
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Ulugbek Toshtemirov" },
                    new Employee { EmployeeName = "Yusupov Xondamir" }
                }
            };
            string filePath = @"C:\Users\Ulugbek_Toshtemirov\Desktop\.NET Mentoring\Epam_NET_Mentoring\Modul-11\Modul11.Task1.XmlSerializationApp\department.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Department));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, dept);
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                Department deserializedDept = (Department)serializer.Deserialize(stream);
                Console.WriteLine($"Department: {deserializedDept.DepartmentName}");
                foreach (var emp in deserializedDept.Employees)
                {
                    Console.WriteLine($"Employee: {emp.EmployeeName}");
                }
            }
        }
    }
}
