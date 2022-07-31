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
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {

            filme.Id = id++;
            filmes.Add(filme);

            // CreatedAtAction retorna a ação que criou este recurso. É uma convenção de boas prátcas usar juntamente com o verbo HttpPost para informar onde o recurso pode ser acessado.
            // nameof para indicar que vou passar o nome da action que precisou executar para recuperar o recurso, que no caso é RecuperaFilmeporID
            // no segundo parâmetro, colocamos os valores que usamos na rota, que no caso é o id do filme que acabamos de criar.
            // no terceiro parâmetro passamos o object em si que estamos tratando, que no caso é o filme.
            return CreatedAtAction(nameof(RecuperaFilmeporID), new { Id = filme.Id}, filme);

        }


        //O IActionResult se refere às respostas do método HTTP.
        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(filmes);
        }

        //Na busca, usa-se o parâmetro na url. Ex: http://localhost:5000/filmes/4. Se não passar, cai na rota do get geral.
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmeporID(int id)
        {
          Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
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
