using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Helpers
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }

    }
}
