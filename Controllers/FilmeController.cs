using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public void AdicionarFilme([FromBody] Filme filme)
        {

            filme.Id = id++;
            filmes.Add(filme);


        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return filmes;
        }

        //Na busca, usa-se o parâmetro na url. Ex: http://localhost:5000/filmes/4. Se não passar, cai na rota do get geral.
        [HttpGet("{id}")]
        public Filme RecuperaFilmeporID(int id)
        {
           return filmes.FirstOrDefault(filme => filme.Id == id);
        }
      
        // Essa sintaxe foi substituída nas linhas acima por uma sintaxe própria do C#
        //{
        //    //foreach( Filme filme in filmes)
        //    //{
        //    //    if (filme.Id == id)
        //    //    {
        //    //        return filme;
        //    //    }
        //    //}
        //    //return null;
        //}
    }
}
