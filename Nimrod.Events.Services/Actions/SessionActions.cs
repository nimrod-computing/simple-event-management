using System;
using System.Collections.Generic;
using AutoMapper;
using Nimrod.Events.DataAccess.EF;
using Nimrod.Events.DomainModel;
using Nimrod.Events.Services.Actions.Base;

namespace Nimrod.Events.Services.Actions
{
    public class SessionActions : EventActions, ISessionActions
    {
        private readonly IMapper _mapper;

        public SessionActions(IMapper mapper, EventsDb db) : base(db)
        {
            _mapper = mapper;
        }

        public Session Update(Session session)
        {
            try
            {
                Session entity = _db.Sessions.Find(session.Id);
                _mapper.Map(session, entity);
                _db.SaveChanges();
                return entity;
            }
            catch (InvalidOperationException)
            {
                throw new KeyNotFoundException();
            }
        }

        public Session Add(Session session)
        {
            _db.Sessions.Add(session);
            _db.SaveChanges();
            return session;
        }

        public void Delete(int id)
        {
            try
            {
                Session session = _db.Sessions.Find(id);
                _db.Sessions.Remove(session);
                _db.SaveChanges();

            }
            catch (InvalidOperationException)
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
