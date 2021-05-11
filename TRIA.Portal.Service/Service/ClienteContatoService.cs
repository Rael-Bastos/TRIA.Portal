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
    public class ClienteContatoService : IClienteContatoService
    {
        private readonly IClienteContatoRepository _ClienteContatoRepository;
        private readonly IUnitOfWork _uow;
        public ClienteContatoService(IClienteContatoRepository ClienteContatoRepository, IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _ClienteContatoRepository = ClienteContatoRepository;

        }
        public async Task<ClienteContatoDTO> Inserir(ClienteContatoDTO clienteContatoDTO)
        {
            try
            {
                var retorno = await _ClienteContatoRepository.Inserir(new ClienteContato(clienteContatoDTO));
                _uow.SaveChanges();
                if (retorno > 0)
                    return new ClienteContatoDTO();
                else
                    return new ClienteContatoDTO("Erro ao inserir cliente Servicço");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ClienteContatoDTO> Alterar(ClienteContatoDTO clienteContatoDTO)
        {
            try
            {
                var cliente = await _ClienteContatoRepository.ConsultarPorIdAsNoTraking(x => x.Id == clienteContatoDTO.Id);
                if (cliente != null)
                {
                    _uow.Detach(cliente);
                    cliente.Alterar(clienteContatoDTO);
                    var retorno = await _ClienteContatoRepository.Alterar(cliente);
                    _uow.SaveChanges();
                    if (retorno > 0)
                        return new ClienteContatoDTO();
                    else
                        return new ClienteContatoDTO("Erro ao alterar cliente ");
                }
                else
                    return new ClienteContatoDTO("Não foi possivel encontrar o cliente cadastrado");
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ClienteContatoDTO> Excluir(int idCliente)
        {
            try
            {
                var cliente = await _ClienteContatoRepository.ConsultarPorId(idCliente);
                if (cliente != null)
                {
                    var retorno = await _ClienteContatoRepository.Excluir(cliente);
                    _uow.SaveChanges();
                    if (retorno > 0)
                        return new ClienteContatoDTO();
                    else
                        return new ClienteContatoDTO("Erro ao excluir cliente Serviço");
                }
                else
                    return new ClienteContatoDTO("Não foi possivel encontrar o cliente cadastrado");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ClienteContatoDTO>> ConsultarClientes()
        {
            try
            {
                var clientes = await _ClienteContatoRepository.ConsultarTodos();

                return ClienteContatoDTO.ConverterListaDTO(clientes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ClienteContatoDTO> ConsultarPorId(int idCliente)
        {
            try
            {
                var cliente = await _ClienteContatoRepository.ConsultarPorId(idCliente);

                return new ClienteContatoDTO(cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
