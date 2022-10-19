using Core.Domain.Entities;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Developer : User
    {
        public ICollection<ProfileLink>? ProfileLinks { get; set; }
    }
}
