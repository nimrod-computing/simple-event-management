using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nimrod.Events.DomainModel.Metadata;

namespace Nimrod.Events.DomainModel
{
    public class Session : Entity
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public string Abstract { get; set; }
        public bool IsPlenary { get; set; }
        public int? Capacity { get; set; }

        public ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();
        public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
    }
}
