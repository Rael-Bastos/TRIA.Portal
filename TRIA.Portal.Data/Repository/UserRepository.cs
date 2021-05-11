using System;
using System.Collections.Generic;
using System.Text;
using TRIA.Portal.Data.Context;
using TRIA.Portal.Domain.Entity;
using TRIA.Portal.Domain.Interfaces.Repository;

namespace TRIA.Portal.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DefaultContext context): base(context)
        {

        }
    }
}
