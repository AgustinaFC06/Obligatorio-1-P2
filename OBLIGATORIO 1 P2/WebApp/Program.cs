namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.MapStaticAssets();

            app.UseRouting();

            app.UseSession(); // modifique orden que abre session, antes de los controladores

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Anonimo}/{action=Login}/{id?}")      // con esto hago que apenas habra la web vaya al login y no a home/index
                .WithStaticAssets();

            app.Run();
        }
    }
}
