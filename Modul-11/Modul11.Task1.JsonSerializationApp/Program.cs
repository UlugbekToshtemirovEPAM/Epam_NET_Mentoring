using Newtonsoft.Json;

namespace Modul11.Task1.JsonSerializationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department dept = new Department
            {
                DepartmentName = "IT_Department_JSON",
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Ulugbek Toshtemirov" },
                    new Employee { EmployeeName = "Yusupov Xondamir" }
                }
            };
            string filePath = @"C:\Users\Ulugbek_Toshtemirov\Desktop\.NET Mentoring\Epam_NET_Mentoring\Modul-11\Modul11.Task1.JsonSerializationApp\department.json";

            string json = JsonConvert.SerializeObject(dept);
            File.WriteAllText(filePath, json);

            string readJson = File.ReadAllText(filePath);
            Department deserializedDept = JsonConvert.DeserializeObject<Department>(readJson);
            Console.WriteLine($"Department: {deserializedDept.DepartmentName}");
            foreach (var emp in deserializedDept.Employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }
        }
    }
}
