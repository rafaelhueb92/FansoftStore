using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fansoft.Store.Domain.Entities
{
    [Table(nameof(TipoProduto))]
    public class TipoProduto : Entity
    {
        [Column(TypeName = "varchar")]
        [StringLength(100), Required]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    }
}
