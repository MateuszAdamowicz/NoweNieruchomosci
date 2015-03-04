using System;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;

namespace NieruchomosciJG.App_Start
{
    public class MapperConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<Photo, UploadedPhoto>().ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Thumbnail));
            Mapper.CreateMap<Photo, PhotoViewModel>().ForMember(dest => dest.Thumbnail, opts => opts.MapFrom(src => String.Format("/Content/Photos/{0}", src.Thumbnail)));
            Mapper.CreateMap<AdvertType, AdvertTypeViewModel>();
            Mapper.CreateMap<CreateAdvertViewModel, Advert>();
            Mapper.CreateMap<PhotoViewModel, Photo>();
            Mapper.CreateMap<PropertyViewModel, Property>();
            Mapper.CreateMap<AdvertTypeViewModel, AdvertType>();
            Mapper.CreateMap<Advert, NewestAdvert>().
                ForMember(dst => dst.Picture, opts => opts.MapFrom(x => x.Photos.FirstOrDefault()))
                .ForMember(dst => dst.AdType, opts => opts.MapFrom(x => x.AdvertType.Name));

            Mapper.CreateMap<Advert, ShowAdvertViewModel>()
                .ForMember(x => x.AdvertType, opts => opts.MapFrom(x => x.AdvertType.Name));
        }
    }
}