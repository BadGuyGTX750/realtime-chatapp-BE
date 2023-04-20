using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace chatapp.Dtos
{
    public class Conversation
    {
        [Key]
        [Required]
        public Guid conversation_id { get; set; }

        [Required]
        public string conversation_name { get; set; }

        [Required]
        public List<Message> messages { get; set; }

        [JsonIgnore]
        public List<GroupMember> group_members { get; set; }
    }
}
