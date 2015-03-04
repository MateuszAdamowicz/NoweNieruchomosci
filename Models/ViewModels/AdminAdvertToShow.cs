using System;
using System.IO;
using System.Web;
using Context.PartialModels;

namespace Models.ViewModels
{
    public class AdminAdvertToShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public bool Visible { get; set; }
        public AdvertTypeViewModel AdType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Number { get; set; }
        public bool Deleted { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public bool ToLet { get; set; }
        public string Thumbnail { get; set; }

        public string GetPhotoPath
        {
            get
            {
                if (File.Exists(HttpContext.Current.Request.MapPath("/Content/Photos/" + Thumbnail)))
                {
                    return String.Format("/Content/Photos/{0}", Thumbnail);
                }
                else
                {
                    return "";
                }
            }
        }
    }

}
