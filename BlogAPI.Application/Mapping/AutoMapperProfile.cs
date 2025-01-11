using AutoMapper;
using BlogAPI.Entites.DO;
using BlogAPI.Entites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Mapping
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category,CategoryViewModel>().ReverseMap();
            CreateMap<Post,PostViewModel>().ReverseMap();
            CreateMap<CreatePostViewModel,Post>().ReverseMap();

        }
    }
}
