

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Nimrod.Events.Api.Models;
using Nimrod.Events.DomainModel;
using Nimrod.Events.Services.Actions;
using Nimrod.Events.Services.Factories;
using Nimrod.Events.Services.Queries;

namespace Nimrod.Events.Api.Controllers
{
    public class SessionsController : ApiController
    {
        private readonly ISessionQueries _sessionsQueries;
        private readonly ISessionActions _sessionsActions;
        private readonly IMapper _mapper;

        public SessionsController(IEventQueriesFactory queriesFactory, IEventActionsFactory actionsFactory, IMapper mapper)
        {
            _mapper = mapper;
            _sessionsQueries = queriesFactory.SessionQueries();
            _sessionsActions = actionsFactory.SessionActions();
        }

        public IList<SessionResource> Get()
        {
            return _sessionsQueries.GetAll().ProjectTo<SessionResource>().ToList();
        }

        [ResponseType(typeof(SessionResource))]
        public IHttpActionResult Get(int id)
        {
            Session session = _sessionsQueries.Single(id);
            if (session == null)
                return NotFound();

            return Ok(session);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SessionResource session)
        {
            if (session == null)
                ModelState.AddModelError("session", "No data");
            if (!ModelState.IsValid)
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            session.Id = id;

            Session updated;
            try
            {
                updated = _sessionsActions.Update (Entity(session));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok(Resource(updated));
        }

        [ResponseType(typeof(SessionResource))]
        public IHttpActionResult Post(SessionResource session)
        {
            if (session == null)
                ModelState.AddModelError("session", "No data"); if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

         var entity =   _sessionsActions.Add(Entity(session));

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, Resource(entity));
        }

        [ResponseType(typeof(Session))]
        public IHttpActionResult Delete(int id)
        {
            _sessionsActions.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        private SessionResource Resource(Session entity)
        {
            return _mapper.Map<SessionResource>(entity);
        }

        private Session Entity(SessionResource resource)
        {
            return _mapper.Map<Session>(resource);
        }
    }
}