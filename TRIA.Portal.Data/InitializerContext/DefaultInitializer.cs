using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TRIA.Portal.Domain.Entity;

namespace TRIA.Portal.Data.InitializerContext
{
    public static class DefaultInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoServico>().HasData(new ProdutoServico { Id = 1, DtInclusao = DateTime.Now, NmProdutoServico = "Desenvolvimento de App" },
                                                          new ProdutoServico { Id = 2, DtInclusao = DateTime.Now, NmProdutoServico = "Desenvolvimento Web" },
                                                          new ProdutoServico { Id = 3, DtInclusao = DateTime.Now, NmProdutoServico = "Integração com SAP" },
                                                          new ProdutoServico { Id = 4, DtInclusao = DateTime.Now, NmProdutoServico = "Integração com Mastersaf" },
                                                          new ProdutoServico { Id = 5, DtInclusao = DateTime.Now, NmProdutoServico = "Suporte Nível Especialista" },
                                                          new ProdutoServico { Id = 6, DtInclusao = DateTime.Now, NmProdutoServico = "Solução Tributária" }
                                                          
                                                          );

        }
    }
}
