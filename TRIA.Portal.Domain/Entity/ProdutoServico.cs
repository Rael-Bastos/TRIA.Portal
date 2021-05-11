using System;
using System.Collections.Generic;
using System.Text;
using TRIA.Portal.Domain.DTO;

namespace TRIA.Portal.Domain.Entity
{
    public class ProdutoServico
    {
        public ProdutoServico()
        {

        }
        public ProdutoServico(ProdutoServicoDTO produtoServicoDTO)
        {
            Id = produtoServicoDTO.Id;
            NmProdutoServico = produtoServicoDTO.NmProdutoServico;
            DtInclusao = DateTime.Now;
        }

        public int Id { get; set; }

        public string NmProdutoServico { get; set; }

        public DateTime DtInclusao { get; set; }

        public List<ClienteContato> ClienteContatos { get; set; }


    }
}
