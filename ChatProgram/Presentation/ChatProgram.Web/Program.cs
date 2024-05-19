namespace ChatProgram.Web;

public sealed class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMvc();

        var app = builder.Build();
        app.UseRouting();
        app.MapDefaultControllerRoute();

        app.Run();
    }
}
