using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Models.DBEntities;
using FurryFit.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Syncfusion.DataSource.Extensions;

namespace FurryFit.DB.Repository
{
    public class UsersRepository :  IUsersRepository 
    {
        private readonly DatabaseContext _databaseContext;
        public UsersRepository(string dbPath) 
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                var tracking = await _databaseContext.Users.AddAsync(user);
                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == EntityState.Added;
                return isAdded;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _databaseContext.Users.FindAsync(id);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                var users = await _databaseContext.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> QueryUserAsync(Func<User, bool> predicate)
        {
            try
            {
                
                var users =  _databaseContext.Users.Where(predicate);
                return users.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            try
            {
                var user = await _databaseContext.Users.FindAsync(id);
                var tracking = _databaseContext.Users.Remove(user);
                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == EntityState.Deleted;
                return isDeleted;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                var tracking =  _databaseContext.Users.Update(user);
                await _databaseContext.SaveChangesAsync();
                var isUpdated = tracking.State == EntityState.Modified;
                return isUpdated;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
