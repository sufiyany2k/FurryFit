using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Database;
using FurryFit.Models.DBEntities;
using FurryFit.Repository.Interface;
using SQLite;

namespace FurryFit.Repository
{
    public class UserRepository : IUsersRepository
    {
        private static SQLiteAsyncConnection _db;

        public UserRepository()
        {
            _db = App.Database.SqLiteAsyncConnection;
            //_db.DropTableAsync<Models.DBEntities.User>().Wait();
            _db.CreateTableAsync<Models.DBEntities.User>().Wait();

        }

        public  bool AddUserAsync(User user)
        {
            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Started");
            bool isSuccess = false;
            try
            {
                var inserted =  _db.InsertAsync(user).Result;
                if (inserted>0)
                    isSuccess= true;
                return isSuccess;
            }
            catch (Exception ex)
            {
                App.Logger.Error(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;

            }
            finally
            {
                App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Completed");
            }

        }

        public Task<User> GetUserByIdAsync(int id)
        {

            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Started");
            try
            {
                return _db.Table<User>().FirstOrDefaultAsync(t => t.Id == id);

            }
            catch (Exception ex)
            {
                App.Logger.Error(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                return null;
            }
            finally
            {
                App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Completed");
            }

            
        }

        Task<IEnumerable<User>> IUsersRepository.GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IUsersRepository.QueryUserAsync(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUsersRepository.RemoveUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUsersRepository.UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
