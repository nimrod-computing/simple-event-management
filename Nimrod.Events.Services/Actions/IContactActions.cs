using Nimrod.Events.DomainModel;
using Nimrod.Events.Services.Actions.Base;

namespace Nimrod.Events.Services.Actions
{
    public interface IContactActions : IEventActions
    {
        Contact Update(Contact contact);
        Contact Add(Contact contact);
        void Delete(int id);
    }
}
