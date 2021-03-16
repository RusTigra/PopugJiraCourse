using AutoMapper;

namespace TaskBoard.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Database.Models.PopugTask, Models.Output.PopugTaskView>();

            CreateMap<Models.Input.PopugTaskCreateView, Database.Models.PopugTask>();
        }
    }
}
