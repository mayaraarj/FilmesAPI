using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

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

// Depois de fazer as configurações de banco de dados, adicione uma Migration indo em Ferramentas - Gerenciador de pacotes
// Nuget - Console do Gerenciador de Pacotes. No console, use o comando Add-Migration Nome do versionamento do banco de dados.
// Ex: Add-Migration CriandoTabeladeFilmes.

// Não se esqueça de fazer o comando Update-Database, pois é isso que fará que a Migration seja utilizada