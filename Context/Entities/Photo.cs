namespace Context.Entities
{
    public class Photo:BusinessObject
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public virtual Advert Advert { get; set; }
    }
}