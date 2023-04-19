using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chatapp.Dto
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

        [Required]
        public Guid conversation_id { get; set; }
    }
}
