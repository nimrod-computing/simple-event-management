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
    public class ContactsController : ApiController
    {
        private readonly IContactQueries _contactsQueries;
        private readonly IContactActions _contactsActions;
        private readonly IMapper _mapper;

        public ContactsController(IEventQueriesFactory queriesFactory, IEventActionsFactory actionsFactory, IMapper mapper)
        {
            _mapper = mapper;
            _contactsQueries = queriesFactory.ContactQueries();
            _contactsActions = actionsFactory.ContactActions();
        }

        public ContactsCollection Get()
        {
            return Collection(_contactsQueries.GetAll().ProjectTo<ContactResource>());
        }

        [ResponseType(typeof(ContactResource))]
        public IHttpActionResult Get(int id)
        {
            Contact contact = _contactsQueries.Single(id);
            if (contact == null)
                return NotFound();

            return Ok(Resource( contact));
        }   

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, ContactResource contact)
        {
            if (contact == null)
                ModelState.AddModelError("contact", "No data");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            contact.Id = id;

            Contact updated;
            try
            {
                updated = _contactsActions.Update(Entity(contact));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
           return Ok(Resource(updated));
        }

        [ResponseType(typeof(ContactResource))]
        public IHttpActionResult Post(ContactResource contact)
        {
            if (contact == null)
                ModelState.AddModelError("contact", "No data");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Contact entity = _contactsActions.Add(Entity(contact));
            return CreatedAtRoute("DefaultApi", new {id = entity.Id}, Resource(entity));
        }

        [ResponseType(typeof(ContactResource))]
        public IHttpActionResult Delete(int id)
        {
            _contactsActions.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        private ContactResource Resource(Contact entity) => _mapper.Map<ContactResource>(entity);

        private Contact Entity(ContactResource resource) => _mapper.Map<Contact>(resource);

        private ContactsCollection Collection(IEnumerable<ContactResource> resources) => new ContactsCollection(resources);
    }
}