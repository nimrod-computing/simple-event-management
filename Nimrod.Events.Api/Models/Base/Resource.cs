using System;
using WebApi.Hal;

namespace Nimrod.Events.Api.Models.Base
{
    public class Resource : Representation
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}