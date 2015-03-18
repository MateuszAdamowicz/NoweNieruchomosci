using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
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
            Mapper.CreateMap<Photo, PhotoViewModel>().ForMember(dest => dest.Thumbnail, opts => opts.MapFrom(src => String.Format("/Content/Photos/{0}", src.Thumbnail)))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => String.Format("/Content/Photos/{0}", src.Name)));
            Mapper.CreateMap<AdvertType, AdvertTypeViewModel>();
            Mapper.CreateMap<CreateAdvertViewModel, Advert>().ForMember(dest => dest.Visible, opts => opts.UseValue(true));
            Mapper.CreateMap<PhotoViewModel, Photo>();
            Mapper.CreateMap<PropertyViewModel, Property>();
            Mapper.CreateMap<AdvertTypeViewModel, AdvertType>();
            Mapper.CreateMap<Advert, NewestAdvert>().
                ForMember(dst => dst.Picture, opts => opts.MapFrom(x => Mapper.Map<PhotoViewModel>(x.Photos.FirstOrDefault())))
                .ForMember(dst => dst.AdType, opts => opts.MapFrom(x => x.AdvertType.Name))
                .ForMember(dst => dst.Number, opts => opts.MapFrom(x => x.Id));

            Mapper.CreateMap<Advert, ShowAdvertViewModel>()
                .ForMember(x => x.AdvertType, opts => opts.MapFrom(x => x.AdvertType.Name))
                .ForMember(x => x.Photos, opts => opts.MapFrom(x => Mapper.Map<List<PhotoViewModel>>(x.Photos)))
                .ForMember(x => x.Number, opts => opts.MapFrom(x => x.Id));

            Mapper.CreateMap<Property, PropertyViewModel>();

            Mapper.CreateMap<Advert, SimplifyAdvert>().ForMember(x => x.Photo, opts => opts.MapFrom(x => x.Photos.FirstOrDefault()))
                .ForMember(x => x.Number, opts => opts.MapFrom(src => src.Id));

            Mapper.CreateMap<Advert, AdminAdvertToShow>()
                .ForMember(x => x.Number, opts => opts.MapFrom(src => src.Id))
                .ForMember(x => x.Thumbnail, opts => opts.MapFrom(x => x.Photos.FirstOrDefault().Thumbnail))
                .ForMember(x => x.AdType, opts => opts.MapFrom(x => x.AdvertType));

            Mapper.CreateMap<EmailMessage, MailMessage>();
            Mapper.CreateMap<MailMessage, Message>();

            Mapper.CreateMap<Advert, CreateAdvertViewModel>();

            Mapper.CreateMap<Message, MessageViewModel>();

            Mapper.CreateMap<AdvertContactEmailViewModel, Message>();
            Mapper.CreateMap<ContactEmailViewModel, Message>();
            Mapper.CreateMap<CreateOfferViewModel, Message>();
        }
    }
}