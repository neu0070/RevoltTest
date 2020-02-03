using RevoltTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevoltTest.Repository
{
    public interface IUserActivityRepo
    {
        Task InsertUserActivity(UserActivity model);
    }
}
