using Nimrod.Events.DataAccess.EF;

namespace Nimrod.Events.Services.Queries.Base
{
    public class EventQueries : Queries<EventsDb>, IEventQueries
    {
        public EventQueries(EventsDb db) : base(db)
        {
        }
    }
}