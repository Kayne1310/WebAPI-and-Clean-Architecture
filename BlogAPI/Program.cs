using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlogAPI.Data;
using BlogAPI.Application.IServices;
using BlogAPI.Application.Services;
using BlogApi.Infrastructure.Repositories;
using BlogAPI.Application.Mapping;

namespace BlogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BlogAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BlogAPIContext"),b=>b.MigrationsAssembly("BlogApi.Infrastructure"))) ;

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICategoryServices,CategoryService>();
            builder.Services.AddScoped<ICategory, RestCategory>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<IPost, RestPost>();
            builder.Services.AddScoped<IPostServices, PostService>();




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
