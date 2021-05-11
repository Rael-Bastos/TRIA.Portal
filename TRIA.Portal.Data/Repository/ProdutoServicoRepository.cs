using TRIA.Portal.Data.Context;
using TRIA.Portal.Domain.Entity;
using TRIA.Portal.Domain.Interfaces.Repository;

namespace TRIA.Portal.Data.Repository
{
    public class ProdutoServicoRepository : BaseRepository<ProdutoServico>, IProdutoServicoRepository
    {
        public ProdutoServicoRepository(DefaultContext context): base(context)
        {

        }
    }
}
