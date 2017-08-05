using System;
using Newtonsoft.Json;
using WebApi.Hal;

namespace Nimrod.Events.Api.Models.Base
{
    public class Resource : Representation
    {
        [JsonProperty("_time")]
        public DateTime? UpdatedAt { get; set; }
    }
}