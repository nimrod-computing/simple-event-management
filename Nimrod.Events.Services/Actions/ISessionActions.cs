using Nimrod.Events.DomainModel;
using Nimrod.Events.Services.Actions.Base;

namespace Nimrod.Events.Services.Actions
{
    public interface ISessionActions : IEventActions
    {
        Session Update(Session session);
        Session Add(Session session);
        void Delete(int id);
    }
}