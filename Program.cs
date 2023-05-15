using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data;
using System;
using System.Reflection;

namespace SchoolAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContextPool<SchoolDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContextConnection"));
            }
          );

            // Add services to the container.
            builder.Services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 1);
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
                //opt.ApiVersionReader = new HeaderApiVersionReader("X-Version");
                //opt.ApiVersionReader = new QueryStringApiVersionReader("ver");
            });

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ICourceRepository, CourseRepository>();
            builder.Services.AddScoped<IFinalRepository, FinalRepository>();    

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}