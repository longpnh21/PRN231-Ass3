using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Entities
{
    public class User : IdentityUser
    {
        [StringLength(40)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
    }
}
