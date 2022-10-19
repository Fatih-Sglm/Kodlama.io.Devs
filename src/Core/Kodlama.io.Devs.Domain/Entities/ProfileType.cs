using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProfileType : Entity<Guid>
    {
        public string PType { get; set; }
        public ICollection<ProfileLink> ProfileLinks { get; set; }
    }
}
