using System.Collections.Generic;
using Models.ViewModels;

namespace Services.NewestAdvertsService
{
    public interface INewestAdvertsService
    {
        IEnumerable<NewestAdvert> GetNewest(int count);
    }
}