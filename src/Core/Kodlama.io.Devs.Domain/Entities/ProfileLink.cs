using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProfileLink : Entity<Guid>
    {
        public Guid ProfileTypeId { get; set; }
        public ProfileType ProfileType { get; set; }
        public string ProfileUrl { get; set; }
        public Developer? Developer { get; set; }
        public Guid? DeveloperId { get; set; }
    }
}
