
using Microsoft.EntityFrameworkCore;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure;
using SchoolProject.Services;
using SchoolProject.Core;
using SchoolProject.Core.MiddelWare;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;
using SchoolProject.Data.IdentityEntites;
using Microsoft.AspNetCore.Identity;


namespace SchoolProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplactionDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext")));

            builder.Services.AddInfrastructureDepdndencies(); 
            builder.Services.AddServicesDependencies();
            builder.Services.AddCoresDependencies();
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplactionDbContext>()
                .AddDefaultTokenProviders(); 

            #region Localization
            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
    };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            builder.Services.AddCors(op =>
              op.AddPolicy(name: "MyCore", policy =>
              {
                  policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
              })); 

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region Localization Middleware
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            #endregion

            app.UseMiddleware<ErrorHandlerMiddleware>();


            app.UseHttpsRedirection();

            app.UseCors("MyCore"); 

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
