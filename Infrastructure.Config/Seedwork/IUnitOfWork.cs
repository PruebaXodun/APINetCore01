using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Config.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void CommitAsync();
        void RollbackChanges();
    }
}
