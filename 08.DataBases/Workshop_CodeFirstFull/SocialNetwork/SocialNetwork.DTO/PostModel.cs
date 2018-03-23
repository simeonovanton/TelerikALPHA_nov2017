using AutoMapper;
using SocialNetwork.Common.Mapping;
using SocialNetwork.Models;
using System;

namespace SocialNetwork.Logic.Models
{
    public class PostModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string ContentPlusDate { get; set; }

        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostModel>().ForMember(x => x.ContentPlusDate, cfg => cfg.MapFrom(x => x.Content + " " + x.PostedOn));
        }
    }
}
