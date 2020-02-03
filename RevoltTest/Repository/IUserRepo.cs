using RevoltTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevoltTest.Repository
{
    public interface IUserRepo
    {
        Task UpdateUserIDs();
        Task SendEmail(string to, string text);
        Task<List<ApplicationUser>> GetAllUser();
        Task<string> GetApplicationUserID(string id1, string id2);
    }
}
