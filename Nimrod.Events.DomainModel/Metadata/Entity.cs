using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nimrod.Events.DomainModel.Metadata
{
    public class Entity
    {
        public DateTime? CreatedAt { get; set; }
        [Index]
        public DateTime? UpdatedAt { get; set; }
    }
}
