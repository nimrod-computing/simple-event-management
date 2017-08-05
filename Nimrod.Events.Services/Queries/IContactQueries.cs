using System.Linq;
using Nimrod.Events.DomainModel;
using Nimrod.Events.Services.Queries.Base;

namespace Nimrod.Events.Services.Queries
{
    public interface IContactQueries : IEventQueries
    {
        IQueryable<Contact> GetAll();
        Contact Single(int id);
    }
}
