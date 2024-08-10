namespace Modul15.ProductOrder.EF.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
            builder.Services.AddDatabase(builder.Configuration);

            var app = builder.Build();


            app.Run();
        }
    }
}
