using Fansoft.Store.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fansoft.Store.Domain.Entities
{
    [Table("Cliente")]
    public class Cliente : Entity
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Limite excedido")]
        [Column(TypeName = "varchar")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione um dos itens")]
        public Sexo Sexo { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
            = new List<Pedido>();
    }
}
