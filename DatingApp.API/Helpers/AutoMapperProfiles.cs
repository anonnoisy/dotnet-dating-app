using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(destination => destination.PhotoUrl, option => 
                    option.MapFrom(src => src.Photos.FirstOrDefault(photo => photo.IsMain).Url)
                )
                .ForMember(destination => destination.Age, option =>
                    option.MapFrom(src => src.DateOfBirth.CalculateAge())
                );

            CreateMap<User, UserForDetailDto>()
                .ForMember(destination => destination.PhotoUrl, option => 
                    option.MapFrom(src => src.Photos.FirstOrDefault(photo => photo.IsMain).Url)
                )
                .ForMember(destination => destination.Age, option =>
                    option.MapFrom(src => src.DateOfBirth.CalculateAge())
                );

            CreateMap<Photo, PhotosForDetailDto>();
        }
    }
}