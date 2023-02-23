using Core.Domain.Base;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Project : Entity<Guid>
    {
        public string Name { get; set; }
        public string? ProjectUrl { get; set; }

        public List<string> Contirbutes { get; set; }




    }
}
