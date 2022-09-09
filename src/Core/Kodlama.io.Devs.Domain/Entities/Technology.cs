using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Technology : Entity
    {
        public string Name { get; set; }
        public Guid ProgramingLanguageId { get; set; }
        public ProgramingLanguage ProgramingLanguage { get; set; }
    }
}
