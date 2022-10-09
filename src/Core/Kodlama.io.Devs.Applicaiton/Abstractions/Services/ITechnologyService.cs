using Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.CreateTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.DeleteTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.UpdateTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Models;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Queries.GetListTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Queries.GetTechnology;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface ITechnologyService
    {
        Task Create(CreateTechnologyCommand command);
        Task Delete(DeleteTechnologyCommand command);
        Task Update(UpdateTechnologyCommand command);
        Task<TechnologyListModel> Get(GetListTechnologyQuery query);
        Task<GetTechnologyDto> GetById(GetTechnologyQuery query);

    }
}
