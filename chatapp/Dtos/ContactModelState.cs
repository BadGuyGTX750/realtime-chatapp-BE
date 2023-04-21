using System.ComponentModel.DataAnnotations;

namespace chatapp.Dtos
{
    public class ContactModelState
    {
        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string confirm_password { get; set; }
    }
}
