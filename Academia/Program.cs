using Academia.Dados;
using Microsoft.EntityFrameworkCore;

namespace Academia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            // 3º passo da conexão com o banco: String de conexão  ------------------------------------------------------------

            builder.Services.AddDbContext<ContextoBanco>(options =>
           {
               options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoBanco"));

           });

            //-----------------------------------------------------------------------------------------------------------------



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
