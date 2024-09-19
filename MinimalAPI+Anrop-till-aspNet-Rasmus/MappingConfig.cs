using AutoMapper;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs;

namespace MinimalAPI_Anrop_till_aspNet_Rasmus
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Books, BookDTO>().ReverseMap();
            CreateMap<Books, BookCreateDTO>().ReverseMap();
            CreateMap<Books, BookUpdateDTO>().ReverseMap();
        }
    }
}
