using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISMeetup.DomainModel
{
    [Table("Claims")]
    public class UserClaim
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string SubjectId { get; set; }

        [Required]
        [MaxLength(250)]
        public string ClaimType { get; set; }

        [Required]
        [MaxLength(250)]
        public string ClaimValue { get; set; }

        public UserClaim(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public UserClaim()
        {

        }
    }
}
