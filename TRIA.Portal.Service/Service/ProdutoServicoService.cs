using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRIA.Portal.Domain.DTO;
using TRIA.Portal.Domain.Entity;
using TRIA.Portal.Domain.Interfaces.Repository;
using TRIA.Portal.Domain.Interfaces.Services;

namespace TRIA.Portal.Service.Service
{
    public class ProdutoServicoService : IProdutoServicoService
    {
        private readonly IProdutoServicoRepository _produtoServicoRepository;
        private readonly IUnitOfWork _uow;
        public ProdutoServicoService(IProdutoServicoRepository produtoServicoRepository, IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _produtoServicoRepository = produtoServicoRepository;

        }
        public async Task<ProdutoServicoDTO> Inserir(ProdutoServicoDTO produtoServicoDTO)
        {
            try
            {
                var retorno = await _produtoServicoRepository.Inserir(new ProdutoServico(produtoServicoDTO));
                _uow.SaveChanges();
                if (retorno > 0)
                    return new ProdutoServicoDTO();
                else
                    return new ProdutoServicoDTO("Erro ao inserir Produto Servicço");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProdutoServicoDTO> Alterar(ProdutoServicoDTO produtoServicoDTO)
        {
            try
            {
                var produto = await _produtoServicoRepository.ConsultarPorIdAsNoTraking(x => x.Id==produtoServicoDTO.Id);
                if (produto != null)
                {
                    _uow.Detach(produto);
                    var retorno = await _produtoServicoRepository.Alterar(new ProdutoServico(produtoServicoDTO));
                    _uow.SaveChanges();
                    if (retorno > 0)
                        return new ProdutoServicoDTO();
                    else
                        return new ProdutoServicoDTO("Erro ao alterar Produto Serviço");
                }
                else
                    return new ProdutoServicoDTO("Não foi possivel encontrar o produto cadastrado");
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProdutoServicoDTO> Excluir(int idProduto)
        {
            try
            {
                var produto = await _produtoServicoRepository.ConsultarPorIdAsNoTraking(x => x.Id == idProduto);
                if (produto != null)
                {
                    _uow.Detach(produto);
                    var retorno = await _produtoServicoRepository.Excluir(produto);
                    _uow.SaveChanges();
                    if (retorno > 0)
                        return new ProdutoServicoDTO();
                    else
                        return new ProdutoServicoDTO("Erro ao excluir Produto Serviço");
                }
                else
                    return new ProdutoServicoDTO("Não foi possivel encontrar o produto cadastrado");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ProdutoServicoDTO>> ConsultarProdutos()
        {
            try
            {
                var produtos = await _produtoServicoRepository.ConsultarTodos();

                return ProdutoServicoDTO.CoverterListaDTO(produtos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProdutoServicoDTO> ConsultarPorId(int idProduto)
        {
            try
            {
                var produto = await _produtoServicoRepository.ConsultarPorId(idProduto);

                return new ProdutoServicoDTO(produto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
