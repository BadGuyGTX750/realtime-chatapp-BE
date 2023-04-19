using System.ComponentModel.DataAnnotations;

namespace chatapp.Dto
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
    }
}
