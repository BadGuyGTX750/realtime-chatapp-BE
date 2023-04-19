using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace chatapp.Dto
{
    public class GroupMember
    {
        [Key]
        [Required]
        public Guid group_member_id { get; set; }

        [ForeignKey("contact")]
        [Required]
        [JsonIgnore]
        public Guid contact_id { get; set; }

        [JsonIgnore]
        public Contact contact { get; set; }

        [ForeignKey("conversation")]
        [Required]
        [JsonIgnore]
        public Guid conversation_id { get; set; }

        public Conversation conversation { get; set; }

        [Required]
        public DateTime joined_datetime { get; set; }

        [Required]
        public DateTime left_datetime { get;}
    }
}
