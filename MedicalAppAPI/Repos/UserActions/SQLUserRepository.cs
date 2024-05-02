using MedicalAppAPI.Data;
using MedicalAppAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppAPI.Repos.UserActions
{
    public class SQLUserRepository : IUserRepositoryActions
    {
        private readonly UsersDbContext _userDbContext;

        public SQLUserRepository(UsersDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<User> AddUserAsync(User user)
        {
            var newUser = _userDbContext.Users.Add(user).Entity;
            await _userDbContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<List<User>> GetAllUsersAsync(string? filterOn = null, string? filterQuery = null,
            int pageNumber = 1, int pageSize = 1000)
        {
            var users = _userDbContext.Users.AsQueryable();

            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) 
            {
                if(filterOn.Equals("lastName", StringComparison.OrdinalIgnoreCase))
                {
                    users = users.Where(x => x.lastName.Contains(filterQuery));
                }

            }

            //Pagination
            var skipResults = (pageNumber - 1 ) * pageSize;

            return await users.Skip(skipResults).Take(pageSize).ToListAsync();

        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var userToGet = await _userDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (userToGet == null)
            {
                return null;
            }

            return userToGet;
        }

        public async Task<User?> UpdateUserAsync(Guid id, User user)
        {
            var existingUser = await _userDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (existingUser == null)
            {
                return null;
            }

            _userDbContext.Entry(existingUser).CurrentValues.SetValues(user);

            await _userDbContext.SaveChangesAsync();
            return existingUser;

        }


    }
}
