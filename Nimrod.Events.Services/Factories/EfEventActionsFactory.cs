using AutoMapper;
using Nimrod.Events.DataAccess.EF;
using Nimrod.Events.Services.Actions;

namespace Nimrod.Events.Services.Factories
{
    public class EfEventActionsFactory : IEventActionsFactory
    {
        private readonly IMapper _mapper;
        private readonly EventsDb _db = new EventsDb();

        public EfEventActionsFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IContactActions ContactActions() => new ContactActions(_mapper, _db);
        public ISessionActions SessionActions() => new SessionActions(_mapper, _db);
    }
}