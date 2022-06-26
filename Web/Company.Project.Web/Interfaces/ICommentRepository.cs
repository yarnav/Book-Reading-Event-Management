using Company.Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Interfaces
{
    public interface ICommentRepository
    {
        Task<int> PostComment(CommentViewModel response);

        Task<IList<CommentViewModel>> GetComments();

        Task<CommentViewModel> ViewComment(int commentId);

        int EditComment(CommentViewModel response);
    }
}
