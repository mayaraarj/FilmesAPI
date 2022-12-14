using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{

    // DTO - Data Transfer Objects é um padrão de projeto para encapsulamento das informações em classes e estas serão as resposáveis por transferir dados no sistema
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O campo gênero não poderá ultrapassar 30 caracteres")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }
    }
}