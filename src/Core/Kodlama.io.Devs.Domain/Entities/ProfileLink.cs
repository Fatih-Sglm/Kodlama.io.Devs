using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProfileLink : Entity
    {
        public ProfileType ProfileType { get; set; }
        public string ProfileUrl { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid? AppUserId { get; set; }
    }
}
