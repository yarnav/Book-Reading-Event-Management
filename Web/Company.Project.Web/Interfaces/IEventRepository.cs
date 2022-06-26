using Company.Project.Core.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Project.Web.Models;

namespace Company.Project.Web.Interfaces
{
    public interface IEventRepository
    {
        Task<IList<EventViewModel>> GetEvents();
        Task<EventViewModel> ViewDetails(int eventId);
        Task<int> CreateEvent(EventViewModel _event);

        int UpdateEvent(EventViewModel _event);
        Task<IList<EventViewModel>> MyEvents(string organiser);

        Task<IList<CommentViewModel>> GetAllCommentByEventId(int eventId);

    }
}
