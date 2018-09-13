using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fansoft.Store.Domain.Entities
{
    [Table("Produto")]
    public class Produto : Entity
    {
        [Column("NomeDoProduto", TypeName = "varchar")]
        [StringLength(100), Required(ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Id do Tipo inválido")]
        public int TipoProdutoId { get; set; }

        [ForeignKey(nameof(TipoProdutoId))]
        public virtual TipoProduto TipoProduto { get; set; }

        [Required(ErrorMessage = "Valor inválido")]
        [Column(TypeName = "money")]
        public decimal Valor { get; set; }

        [Column(TypeName = "varchar")]
        public string Descricao { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
            = new List<Pedido>();

    }
}
