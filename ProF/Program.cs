using ProF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;




namespace ProF
{
    public class Program
    {
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.Use(async (context, next) =>
			{
				await next();

				if (context.Request.Path == "/login_admin" && context.Response.StatusCode == 302)
				{
					await Task.Delay(5000); //  √ŒÌ— ·„œ… 5 ÀÊ«‰Ú
					await context.Response.WriteAsync("You have been idle for 5 seconds."); // —”«·… »⁄œ «‰ Â«¡ «·„œ…
				}
			});

			// Ì „ Ê÷⁄ «·ﬂÊœ Â‰« »⁄œ «·‹ authentication Ê authorization middleware
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "logout",
					pattern: "logout",
					defaults: new { controller = "Account", action = "Logout" });

				// »«ﬁÌ endpoints Ì „  ⁄—Ì›Â« Â‰«
			});

			// »«ﬁÌ configuration Ì „ Ê÷⁄Â Â‰«
		}

		public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDBcontext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"));
            }); builder.Services.AddSession(
	            options => {
		        options.IdleTimeout = TimeSpan.FromMinutes(30);
		        options.Cookie.HttpOnly = true;
		        options.Cookie.IsEssential = true;
	        }

	);

			


			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
			app.UseSession();
			app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=HOMEpage}/{action=PAGE1}/{id?}");

            app.Run();

        }
    }
}
