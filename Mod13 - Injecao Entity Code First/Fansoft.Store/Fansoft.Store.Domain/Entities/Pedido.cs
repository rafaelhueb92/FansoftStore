using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fansoft.Store.Domain.Entities
{
    [Table("Pedido")]
    public class Pedido:Entity
    {
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
            = new List<Produto>();

    }
}
