using Microsoft.AspNetCore.Identity;

namespace FullCal.Models
{
    public class ApplicationUser :IdentityUser
    {
        public virtual ICollection<Event> Events { get; set; }

    }
}
