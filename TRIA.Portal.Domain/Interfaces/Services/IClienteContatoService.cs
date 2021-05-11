using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TRIA.Portal.Domain.DTO;
using TRIA.Portal.Domain.Entity;

namespace TRIA.Portal.Domain.Interfaces.Services
{
    public interface IClienteContatoService
    {
        Task<ClienteContatoDTO> Inserir(ClienteContatoDTO clienteContatoDTO);
        Task<ClienteContatoDTO> Alterar(ClienteContatoDTO clienteContatoDTO);
        Task<ClienteContatoDTO> Excluir(int idCliente);
        Task<List<ClienteContatoDTO>> ConsultarClientes();
        Task<ClienteContatoDTO> ConsultarPorId(int idCliente);
    }
}
