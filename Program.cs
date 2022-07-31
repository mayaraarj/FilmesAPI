using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI
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

            // Adicionando a configuração de startup do banco de dados
           builder.Services.AddDbContext<FilmeContext>(opts => opts.UseMySql(builder.Configuration.GetConnectionString("FilmeConnection"), new MySqlServerVersion(new Version(8, 0))));

            //Adicionando Automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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