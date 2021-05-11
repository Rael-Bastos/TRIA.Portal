using System;
using System.Collections.Generic;
using System.Text;
using TRIA.Portal.Domain.DTO;

namespace TRIA.Portal.Domain.Entity
{
    public class ClienteContato
    {
        public ClienteContato()
        {

        }
        public ClienteContato(ClienteContatoDTO clienteContatoDTO)
        {
            Id = clienteContatoDTO.Id;
            NmEmpresa = clienteContatoDTO.NmEmpresa;
            NmCliente = clienteContatoDTO.NmCliente;
            Telefone = clienteContatoDTO.Telefone;
            Email = clienteContatoDTO.Email;
            TextoLivre = clienteContatoDTO.TextoLivre;
            DtInclusao = DateTime.Now;
            DtAlteracao = null;
            HrAtendimento = DateTime.Now.ToString("HH:mm");
            IdProdutoServico = clienteContatoDTO.IdProdutoServico;
        }

        public int Id { get; set; }
        
        public string NmEmpresa { get; set; }

        public string NmCliente { get; set; }

        public string Telefone { get; set; }
        
        public string Email { get; set; }
        
        public string TextoLivre { get; set; }
        
        public DateTime DtInclusao { get; set; }
        
        public DateTime? DtAlteracao { get; set; }
        
        public string HrAtendimento { get; set; }

        public int IdProdutoServico { get; set; }
        public ProdutoServico ProdutoServico { get; set; }

        public void Alterar(ClienteContatoDTO clienteContatoDTO)
        {
            this.IdProdutoServico = clienteContatoDTO.IdProdutoServico;
            this.NmEmpresa = clienteContatoDTO.NmEmpresa;
            this.NmCliente = clienteContatoDTO.NmCliente;
            this.Telefone = clienteContatoDTO.Telefone;
            this.TextoLivre = clienteContatoDTO.TextoLivre;
            this.Email = clienteContatoDTO.Email;
            this.DtAlteracao = DateTime.Now;
            this.HrAtendimento = DateTime.Now.ToString("HH:mm");
        }
    }
}
