using System;
using System.Collections.Generic;
using System.Text;
using TRIA.Portal.Domain.Entity;

namespace TRIA.Portal.Domain.DTO
{
    public class ClienteContatoDTO : BaseRetornoDTO
    {
        public ClienteContatoDTO()
        {

        }
        public ClienteContatoDTO(string mensagemRetorno): base(mensagemRetorno)
        {

        }

        public ClienteContatoDTO(ClienteContato clienteContato)
        {
            Id = clienteContato.Id;
            NmEmpresa = clienteContato.NmEmpresa;
            NmCliente = clienteContato.NmCliente;
            Telefone = long.Parse(clienteContato.Telefone.Replace("(","").Replace(")","").Replace("-", "").Replace(" ", "")).ToString(@"(00) 00000-0000"); 
            Email = clienteContato.Email;
            TextoLivre = clienteContato.TextoLivre;
            DtInclusao = clienteContato.DtInclusao.ToString("dd/MM/yyyy");
            DtAlteracao = clienteContato.DtAlteracao?.ToString("dd/MM/yyyy");
            HrAtendimento = clienteContato.HrAtendimento;
            IdProdutoServico = clienteContato.IdProdutoServico;
        }

        public int Id { get; set; }

        public string NmEmpresa { get; set; }

        public string NmCliente { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string TextoLivre { get; set; }

        public string DtInclusao { get; set; }

        public string DtAlteracao { get; set; }

        public string HrAtendimento { get; set; }

        public int IdProdutoServico { get; set; }

        public static List<ClienteContatoDTO> ConverterListaDTO(List<ClienteContato> clienteContatos)
        {
            var retorno = new List<ClienteContatoDTO>();

            clienteContatos.ForEach(cc => retorno.Add(new ClienteContatoDTO(cc)));

            return retorno;
        }
    }
}
