using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using WebApi.Hal;

namespace Nimrod.Events.Api.Models
{
    public class ContactsCollection : SimpleListRepresentation<ContactResource>
    {
        public ContactsCollection(IEnumerable<ContactResource> resources) 
            : base(resources.ToList()) { }

        [JsonProperty("_time")]
        public DateTime Time => DateTime.UtcNow;


        public override string Href => "api/contacts";

        public override string Rel => "contacts";
    }
}