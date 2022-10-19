using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgramingLanguage : Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Technology> Technologies { get; set; }
    }
}
