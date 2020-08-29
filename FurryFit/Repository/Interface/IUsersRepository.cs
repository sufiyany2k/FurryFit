using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Models.DBEntities;

namespace FurryFit.Repository.Interface
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        //Task<bool> AddUserAsync(User user);
        bool AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> RemoveUserAsync(int id);
        
        Task<IEnumerable<User>> QueryUserAsync(Func<User, bool> predicate);
    }
}
