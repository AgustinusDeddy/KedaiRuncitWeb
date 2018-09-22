using AutoMapper;
using Core.Entities;

namespace KedaiRuncitWeb.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemViewModel>();
        }
    }
}
