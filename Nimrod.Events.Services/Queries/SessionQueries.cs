
using System.Linq;
using Nimrod.Events.DataAccess.EF;
using Nimrod.Events.DomainModel;
using Nimrod.Events.Services.Queries.Base;

namespace Nimrod.Events.Services.Queries
{
    public class SessionQueries : EventQueries, ISessionQueries
    {
        public SessionQueries(EventsDb db) : base(db)
        {
        }

        public IQueryable<Session> GetAll()
        {
            return _db.Sessions;
        }

        public Session Single(int id)
        {
            return _db.Sessions.Find(id);
        }
    }
}