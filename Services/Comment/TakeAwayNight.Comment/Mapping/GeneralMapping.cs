using AutoMapper;
using TakeAwayNight.Comment.DAL.Entities;
using TakeAwayNight.Comment.Dtos;

namespace TakeAwayNight.Comment.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
                CreateMap<UserComment,ResultUserCommentDto>().ReverseMap();
                CreateMap<UserComment,CreateUserCommentDto>().ReverseMap();
                CreateMap<UserComment,UpdateUserCommentDto>().ReverseMap();
                CreateMap<UserComment,GetByIdUserCommentDto>().ReverseMap();
                CreateMap<UserComment, GetByProductIdUserCommentDto>().ReverseMap();
            
        }
    }
}
