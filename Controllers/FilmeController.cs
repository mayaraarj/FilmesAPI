﻿using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        //Declarando e iniciando FilmeContext no controlador.
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        //O IActionResult se refere às respostas do método HTTP.

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            //Adicionando filme ao banco de dados
            _context.Filmes.Add(filme);
            _context.SaveChanges();

            // CreatedAtAction retorna a ação que criou este recurso. É uma convenção de boas prátcas usar juntamente com o verbo HttpPost para informar onde o recurso pode ser acessado.
            // nameof para indicar que vou passar o nome da action que precisou executar para recuperar o recurso, que no caso é RecuperaFilmeporID
            // no segundo parâmetro, colocamos os valores que usamos na rota, que no caso é o id do filme que acabamos de criar.
            // no terceiro parâmetro passamos o object em si que estamos tratando, que no caso é o filme.
            return CreatedAtAction(nameof(RecuperaFilmeporID), new { Id = filme.Id }, filme);

        }



        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes;
        }

        //Na busca, usa-se o parâmetro na url. Ex: http://localhost:5000/filmes/4. Se não passar, cai na rota do get geral.
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmeporID(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }


    }
}
