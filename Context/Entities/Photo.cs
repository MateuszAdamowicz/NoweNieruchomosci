namespace Context.Entities
{
    public class Photo:DbTable
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public virtual Advert Advert { get; set; }
    }
}