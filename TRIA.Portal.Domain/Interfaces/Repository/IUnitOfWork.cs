using System;
using System.Collections.Generic;
using System.Text;

namespace TRIA.Portal.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {

        void OpenTransaction();

        void Commit();

        void Rollback();

        void SaveChanges();

        void Detach<T>(T obj);
    }
}
