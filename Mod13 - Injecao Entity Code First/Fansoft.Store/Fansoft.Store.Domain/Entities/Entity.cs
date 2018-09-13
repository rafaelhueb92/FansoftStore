using System;
using System.ComponentModel.DataAnnotations;

namespace Fansoft.Store.Domain.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
