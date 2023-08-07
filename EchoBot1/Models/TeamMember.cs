using System.ComponentModel.DataAnnotations;

namespace EchoBot1.Models
{
    public class TeamMember
    {
        [Key]
        public int MemberId { get; set; }
        public string MemberName { get; set; }
    }
}
