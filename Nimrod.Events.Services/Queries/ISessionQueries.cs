using System.Linq;
using Nimrod.Events.DomainModel;
using Nimrod.Events.Services.Queries.Base;

namespace Nimrod.Events.Services.Queries
{
    public interface ISessionQueries : IEventQueries
    {
        IQueryable<Session> GetAll();
        Session Single(int id);
    }
}
