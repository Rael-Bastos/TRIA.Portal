using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TRIA.Portal.Data.Context;
using TRIA.Portal.Domain.Interfaces.Repository;

namespace TRIA.Portal.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private DefaultContext _context;


        public UnitOfWork(DefaultContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            if (_context.Database.CurrentTransaction != null)
                _context.Database.CommitTransaction();
        }

        public void OpenTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
                _context.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Detach<T>(T obj)
        {
            _context.Entry(obj).State = EntityState.Detached;
        }



    }
}
