using System.ComponentModel.DataAnnotations;

namespace chatapp.Dtos
{
    public class ConversationModelState
    {
        [Required]
        public string conversation_name { get; set; }

        [Required]
        public bool isGroup { get; set; }
    }
}
