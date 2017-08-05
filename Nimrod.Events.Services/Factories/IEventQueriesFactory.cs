using Nimrod.Events.Services.Queries;

namespace Nimrod.Events.Services.Factories
{
    public interface IEventQueriesFactory
    {
        IContactQueries ContactQueries();
        ISessionQueries SessionQueries();
    }
}
