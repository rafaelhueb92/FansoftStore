using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fansoft.Store.Domain.Entities
{
    [Table("Perfil")]
    public class Perfil:Entity
    {
        [Column(TypeName ="varchar")]
        [StringLength(100), Required]
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
            = new List<Usuario>();
    }
}
