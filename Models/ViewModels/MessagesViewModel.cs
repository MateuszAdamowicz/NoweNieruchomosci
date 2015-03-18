using PagedList;

namespace Models.ViewModels
{
    public class MessagesViewModel
    {
        public IPagedList<MessageViewModel> Messages { get; set; }
        public int? Deleted { get; set; }
    }
}