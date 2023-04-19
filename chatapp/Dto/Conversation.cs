using System.ComponentModel.DataAnnotations;

namespace chatapp.Dto
{
    public class Conversation
    {
        [Key]
        [Required]
        public Guid conversation_id { get; set; }

        [Required]
        public string conversation_name { get; set; }
    }
}
