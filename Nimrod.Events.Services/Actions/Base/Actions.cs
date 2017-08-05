using System.Data.Entity;

namespace Nimrod.Events.Services.Actions.Base
{
    public class Actions<TCtx> : IActions<TCtx>
        where TCtx : DbContext
    {
        protected readonly TCtx _db;

        public Actions(TCtx db)
        {
            _db = db;
        }
    }
}
