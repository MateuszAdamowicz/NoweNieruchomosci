using System;
using AutoMapper;
using Context.Entities;
using Models.ViewModels;

namespace NieruchomosciJG
{
    public class MapperConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<Advert, AdminAdvertToShow>()
                .ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id*9999, 18)));
        }
    }
}