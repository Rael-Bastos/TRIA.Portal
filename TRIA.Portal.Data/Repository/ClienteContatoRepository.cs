using TRIA.Portal.Data.Context;
using TRIA.Portal.Domain.Entity;
using TRIA.Portal.Domain.Interfaces.Repository;

namespace TRIA.Portal.Data.Repository
{
    public class ClienteContatoRepository : BaseRepository<ClienteContato>, IClienteContatoRepository
    {
        public ClienteContatoRepository(DefaultContext context): base(context)
        {

        }
    }
}
