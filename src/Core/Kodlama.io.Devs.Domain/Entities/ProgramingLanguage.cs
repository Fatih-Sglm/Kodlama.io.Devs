using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgramingLanguage : Entity
    {
        public string Name { get; set; }
        public ICollection<Technology> Technologies { get; set; }
    }
}
