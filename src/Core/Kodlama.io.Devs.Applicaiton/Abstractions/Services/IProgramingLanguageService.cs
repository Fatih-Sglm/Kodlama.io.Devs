using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IProgramingLanguageService
    {
        Task<ProgramingLanguage?> GetById(Guid id);
    }
}
