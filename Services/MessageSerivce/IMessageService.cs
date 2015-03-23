using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using Models.ViewModels;

namespace Services.MessageSerivce
{
    public interface IMessageService
    {
        IEnumerable<MessageViewModel> GetMessages();
        void DeleteMessage(int id);
    }
}