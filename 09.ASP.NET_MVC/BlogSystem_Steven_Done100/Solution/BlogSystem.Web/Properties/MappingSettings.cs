using AutoMapper;
using BlogSystem.Data.Models;
using BlogSystem.DTO;
using BlogSystem.Web.Models.PostViewModels;

namespace BlogSystem.Infrastructure.Mapping
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            this.CreateMap<PostDto, PostViewModel>()
                   .ForMember(x => x.Author, options => options.MapFrom(x => x.Author.Email))
                   .ReverseMap();

            this.CreateMap<CommentDto, CommentViewModel>()
                   .ForMember(x => x.Author, options => options.MapFrom(x => x.Author.Email))
                   .ReverseMap();

            this.CreateMap<PostViewModel, PostDto>(MemberList.Source);
            this.CreateMap<PostDto, Post>(MemberList.Source);
            this.CreateMap<CommentDto, Comment>(MemberList.Source);
        }
    }
}
