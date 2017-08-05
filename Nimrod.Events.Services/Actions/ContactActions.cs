using System;
using System.Collections.Generic;
using AutoMapper;
using Nimrod.Events.DataAccess.EF;
using Nimrod.Events.DomainModel;
using Nimrod.Events.Services.Actions.Base;

namespace Nimrod.Events.Services.Actions
{
    public class ContactActions : EventActions, IContactActions
    {
        private readonly IMapper _mapper;

        public ContactActions(IMapper mapper, EventsDb db) : base(db)
        {
            _mapper = mapper;
        }

        public Contact Update(Contact contact)
        {
            try
            {
                Contact entity = _db.Contacts.Find(contact.Id);
                _mapper.Map(contact, entity);
                _db.SaveChanges();
                return entity;
            }
            catch (InvalidOperationException)
            {
                throw new KeyNotFoundException();
            }
        }

        public Contact Add(Contact contact)
        {
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            return contact;
        }

        public void Delete(int id)
        {
            try
            {
                Contact contact = _db.Contacts.Find(id);
                _db.Contacts.Remove(contact);
                _db.SaveChanges();

            }
            catch (InvalidOperationException)
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
