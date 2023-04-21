using System.ComponentModel.DataAnnotations;

namespace chatapp.Dtos
{
    public class LoginModelState
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
