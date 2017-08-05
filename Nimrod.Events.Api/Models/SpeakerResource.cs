using Nimrod.Events.Api.Models.Base;

namespace Nimrod.Events.Api.Models
{
    public class SpeakerResource : Resource
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public override string Href => $"api/spekers/{Id}";

        public override string Rel => "speakers";
    }
}
