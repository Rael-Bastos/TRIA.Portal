using Microsoft.EntityFrameworkCore;
using TRIA.Portal.Data.InitializerContext;
using TRIA.Portal.Domain.Entity;

namespace TRIA.Portal.Data.Context
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
            modelBuilder.Entity();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Entity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Tbl_Usuarios");

                entity.Property(e => e.Id).HasColumnName("id_usuario").IsRequired();
                entity.Property(e => e.Username).HasColumnName("username").IsRequired();
                entity.Property(e => e.Password).HasColumnName("senha").IsRequired();
                entity.Property(e => e.NomeCompleto).HasColumnName("nome_completo").IsRequired();
                entity.Property(e => e.Email).HasColumnName("email").IsRequired();
                entity.Property(e => e.DtInclusao).HasColumnName("dt_inclusao").IsRequired();
            });

            modelBuilder.Entity<ProdutoServico>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Tbl_Produto_Servico");

                entity.Property(e => e.Id).HasColumnName("id_produto_servico").IsRequired();
                entity.Property(e => e.NmProdutoServico).HasColumnName("nm_produto_servico").IsRequired();
                entity.Property(e => e.DtInclusao).HasColumnName("dt_inclusao").IsRequired();

                entity.HasMany(e => e.ClienteContatos)
                .WithOne(o => o.ProdutoServico)
                .HasForeignKey(k => k.IdProdutoServico);
            });

            modelBuilder.Entity<ClienteContato>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Tbl_Cliente_Contato");

                entity.Property(e => e.Id).HasColumnName("id_cliente_contato").IsRequired();
                entity.Property(e => e.IdProdutoServico).HasColumnName("id_produto_servico").IsRequired();
                entity.Property(e => e.NmEmpresa).HasColumnName("nm_empresa").IsRequired();
                entity.Property(e => e.NmCliente).HasColumnName("nm_cliente").IsRequired();
                entity.Property(e => e.Telefone).HasColumnName("telefone_contato").IsRequired();
                entity.Property(e => e.Email).HasColumnName("email_contato").IsRequired();
                entity.Property(e => e.TextoLivre).HasColumnName("texto_livre").IsRequired();
                entity.Property(e => e.HrAtendimento).HasColumnName("hr_atendimento").IsRequired();
                entity.Property(e => e.DtInclusao).HasColumnName("dt_inclusao").IsRequired();
                entity.Property(e => e.DtAlteracao).HasColumnName("dt_alteracao");
            });

        }
    }
}
