
using Microsoft.AspNetCore.Identity;

namespace MeinLiX.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
