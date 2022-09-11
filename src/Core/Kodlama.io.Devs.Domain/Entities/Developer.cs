using Core.Security.Entities;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Developer : User
    {
        public ICollection<ProfileLink>? ProfileLinks { get; set; }
    }
}
