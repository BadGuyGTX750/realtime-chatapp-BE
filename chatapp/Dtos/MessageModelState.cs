using System.ComponentModel.DataAnnotations;

namespace chatapp.Dtos
{
    public class MessageModelState
    {
        [Required]
        public string from_email { get; set; }

        [Required]
        public string message_text { get; set; }
    }
}
