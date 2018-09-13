using Fansoft.Store.Domain.Entities;
using System.Data.Entity;

namespace Fansoft.Store.Data.EF
{
    public class FanSoftStoreDataContext : DbContext
    {

        public FanSoftStoreDataContext() : base("FansoftStoreDB")
        {
            //Database.SetInitializer<FanSoftStoreDataContext>(null);
            Database.SetInitializer(new DbInitializer());
            //Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                
                .HasMany(p=>p.Produtos)
                .WithMany(p=>p.Pedidos)
                //Configura a tabela intermediária
                .Map(m=> {
                    m.ToTable("PedidoProduto");
                    m.MapLeftKey("PedidoId");
                    m.MapRightKey("ProdutoId");
                });
        }

    }
}
