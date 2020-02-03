using RevoltTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevoltTest.Repository
{
    public class UserActivityRepo : IUserActivityRepo
    {
        private readonly ApplicationDbContext _context;

        public UserActivityRepo(ApplicationDbContext AppContext)
        {
            _context = AppContext;
        }

        public async Task InsertUserActivity(UserActivity model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }
    }
}
