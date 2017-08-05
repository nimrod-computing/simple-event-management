using Nimrod.Events.DataAccess.EF;
using Nimrod.Events.Services.Queries;

namespace Nimrod.Events.Services.Factories
{
    public class EfEventQueriesFactory : IEventQueriesFactory
    {
        private readonly EventsDb _db = new EventsDb();

        public IContactQueries ContactQueries() => new  ContactQueries(_db);
        public ISessionQueries SessionQueries() => new  SessionQueries(_db);
    }
}