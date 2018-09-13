using System.ComponentModel.DataAnnotations;

namespace Fansoft.Store.Api.Models
{
    public class ProdutoVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage ="O limite do campo Nome é de 100 caracteres")]
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoProdutoId { get; set; }
        public string TipoProdutoNome { get; set; }
    }
}
