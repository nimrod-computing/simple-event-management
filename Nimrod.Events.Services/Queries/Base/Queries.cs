using System.Data.Entity;

namespace Nimrod.Events.Services.Queries.Base
{
    public class Queries<TCtx> : IQueries<TCtx>
        where TCtx : DbContext
    {
        protected TCtx _db;

        public Queries(TCtx db)
        {
            _db = db;
        }
    }
}
