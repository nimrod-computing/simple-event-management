using Nimrod.Events.Services.Actions;

namespace Nimrod.Events.Services.Factories
{
    public interface IEventActionsFactory
    {
        IContactActions ContactActions();
        ISessionActions SessionActions();
    }
}
