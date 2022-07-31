
// Importa no pacote nuget de soluções o EntityFrameworkCore, o Tools e o MySQLEntityFrameworkCore, porque é com ele que vamos usar o banco de dados
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {

        //Como parâmetro do construtor entram as opções desse contexto.
        //O contexto em que estamos trabalhando é o FilmeContext
        public FilmeContext(DbContextOptions<FilmeContext>options) : base(options)
        {

        }

        // O DBSet é o conjunto de dados do banco em que faremos o acesso aos dados de forma encapsulada
        public DbSet<Filme> Filmes { get; set; }
    }
}

// Depois disso, vá pra appsettings.json configurar a senha de conexão com o banco de dados