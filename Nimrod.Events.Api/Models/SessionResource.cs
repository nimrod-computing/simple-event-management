using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nimrod.Events.Api.Models.Base;
using Nimrod.Events.DomainModel;

namespace Nimrod.Events.Api.Models
{
    public class SessionResource : Resource
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public string Abstract { get; set; }
        public bool IsPlenary { get; set; }
        public int? Capacity { get; set; }
    }
}
