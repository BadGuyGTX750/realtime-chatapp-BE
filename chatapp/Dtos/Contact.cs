using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace chatapp.Dtos
{
    public class Contact
    {
        [Key]
        [Required]
        public Guid contact_id { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        public string email { get; set; }

        [JsonIgnore]
        public List<GroupMember> group_members { get; set; }
    }
}
