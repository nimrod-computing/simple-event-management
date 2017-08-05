
using System.ComponentModel.DataAnnotations;
using Nimrod.Events.Api.Models.Base;

namespace Nimrod.Events.Api.Models
{
    public class ContactResource : Resource
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Forename { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string Company { get; set; }
        public string Address { get; set; }
        [StringLength(50)]
        public string Town { get; set; }
        [StringLength(50)]
        public string County { get; set; }
        [StringLength(12)]
        public string PostCode { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string MobilePhone { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Web { get; set; }
    }
}
