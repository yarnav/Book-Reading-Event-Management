using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Interfaces
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}
