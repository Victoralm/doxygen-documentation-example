using Microsoft.AspNetCore.Http;

namespace doxygen_documentation_example.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public Context Session { get; }

        public UnitOfWork(Context session)
        {
            Session = session;
        }

        public void BeginTransaction()
        {
            Session.Transaction = Session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            Session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            Session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => Session.Transaction?.Dispose();
    }
}
