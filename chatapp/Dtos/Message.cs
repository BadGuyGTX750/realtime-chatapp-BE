using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace chatapp.Dtos
{
    public class Message
    {
        [Key]
        [Required]
        public Guid message_id { get; set; }

        [Required]
        public string from_email { get; set; }

        [Required]
        public string message_text { get; set; }

        [Required]
        public DateTime sentAt { get; set; }

        [ForeignKey("conversation")]
        [Required]
        [JsonIgnore]
        public Guid conversation_id { get; set; }

        [JsonIgnore]
        public Conversation conversation { get; set; }
    }
}
