using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TRIA.Portal.Domain.DTO;
using TRIA.Portal.Domain.Entity;

namespace TRIA.Portal.Domain.Interfaces.Services
{
    public interface IProdutoServicoService
    {
        Task<ProdutoServicoDTO> Inserir(ProdutoServicoDTO produtoServicoDTO);
        Task<ProdutoServicoDTO> Alterar(ProdutoServicoDTO produtoServicoDTO);
        Task<ProdutoServicoDTO> Excluir(int idProduto);
        Task<List<ProdutoServicoDTO>> ConsultarProdutos();
        Task<ProdutoServicoDTO> ConsultarPorId(int idProduto);
    }
}
