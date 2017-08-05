using System.Collections.Generic;
using Nimrod.Events.DomainModel.Metadata;

namespace Nimrod.Events.DomainModel
{
    public class Speaker : Entity
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public Contact Details { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
