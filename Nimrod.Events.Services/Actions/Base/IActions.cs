using System.Data.Entity;

namespace Nimrod.Events.Services.Actions.Base
{
    public interface IActions <TCtx>
        where TCtx : DbContext
    {
    }
}
