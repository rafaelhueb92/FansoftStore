using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fansoft.Store.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario : Entity
    {
        [Column(TypeName = "varchar"), Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column(TypeName = "varchar"), Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "varchar"), Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50)]
        public string Senha { get; set; }

        public int PerfilId { get; set; }
        [ForeignKey(nameof(PerfilId))]
        public virtual Perfil Perfil { get; set; }

    }
}
