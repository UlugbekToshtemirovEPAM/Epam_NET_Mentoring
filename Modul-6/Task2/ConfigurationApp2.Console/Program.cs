namespace ConfigurationApp2.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = TimeSpan.FromMinutes(23).ToString();

            var settings = new MySettings();

            settings.LoadSettings();

            System.Console.WriteLine($"Current MyIntSetting: {settings.MyIntSetting}");
            System.Console.WriteLine($"Current MyFloatSetting: {settings.MyFloatSetting}");
            System.Console.WriteLine($"Current MyStringSetting: {settings.MyStringSetting}");

            System.Console.Write("Enter new value for MyIntSetting: ");
            settings.MyIntSetting = int.Parse(System.Console.ReadLine());

            System.Console.Write("Enter new value for MyFloatSetting: ");
            settings.MyFloatSetting = float.Parse(System.Console.ReadLine());

            System.Console.Write("Enter new value for MyStringSetting: ");
            settings.MyStringSetting = System.Console.ReadLine();



            settings.SaveSettings();

            System.Console.WriteLine("Settings saved successfully.");
        }
    }
}
