using System;
using System.Collections.Generic;
using System.Text;
using TRIA.Portal.Domain.Entity;

namespace TRIA.Portal.Domain.DTO
{
    public class ProdutoServicoDTO :BaseRetornoDTO
    {
        public ProdutoServicoDTO()
        {

        }
        public ProdutoServicoDTO(string mensagemRetorno) : base(mensagemRetorno)
        {

        }
        public ProdutoServicoDTO(ProdutoServico produtoServico)
        {
            Id = produtoServico.Id;
            NmProdutoServico = produtoServico.NmProdutoServico;
            DtInclusao = produtoServico.DtInclusao.ToString("dd/MM/yyyy");
        }

        public int Id { get; set; }

        public string NmProdutoServico { get; set; }

        public string DtInclusao { get; set; }

        public static List<ProdutoServicoDTO> CoverterListaDTO(List<ProdutoServico> produtoServicos)
        {
            var retorno = new List<ProdutoServicoDTO>();

            produtoServicos.ForEach(ps => retorno.Add(new ProdutoServicoDTO(ps)));

            return retorno;
        }
    }
}
