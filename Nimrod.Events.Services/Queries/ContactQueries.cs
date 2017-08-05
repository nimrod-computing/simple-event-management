using System.Linq;
using Nimrod.Events.DataAccess.EF;
using Nimrod.Events.DomainModel;
using Nimrod.Events.Services.Queries.Base;

namespace Nimrod.Events.Services.Queries
{
    public class ContactQueries : EventQueries, IContactQueries
    {
        public ContactQueries(EventsDb db) : base(db)
        {
        }

        public IQueryable<Contact> GetAll()
        {
            return _db.Contacts;
        }

        public Contact Single(int id)
        {
            return _db.Contacts.Find(id);
        }
    }
}