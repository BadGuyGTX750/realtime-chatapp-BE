using System.ComponentModel.DataAnnotations;

namespace chatapp.Dto
{
    public class GroupMember
    {
        [Key]
        [Required]
        public Guid group_member_id { get; set; }

        [Required]
        public Guid contact_id { get; set; }

        [Required]
        public Guid conversation_id { get; set; }

        [Required]
        public DateTime joined_datetime { get; set; }

        [Required]
        public DateTime left_datetime { get;}
    }
}
