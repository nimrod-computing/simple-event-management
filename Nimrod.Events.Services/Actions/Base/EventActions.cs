using Nimrod.Events.DataAccess.EF;

namespace Nimrod.Events.Services.Actions.Base
{
    public class EventActions : Actions<EventsDb>, IEventActions
    {
        public EventActions(EventsDb db) : base(db)
        {
        }
    }
}