using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Models.PetProfile;
using SQLite;

namespace FurryFit.Repository
{
    public class PetRepository
    {
        private static SQLiteAsyncConnection _db;

        public PetRepository()
        {
            _db = App.Database.SqLiteAsyncConnection;
            //_db.DropTableAsync<Models.PetProfile.Pet>().Wait();
            _db.CreateTableAsync<Models.PetProfile.Pet>().Wait();

        }

        public Pet GetPetWithIdAsync(int petId)
        {
            var returnValue = _db.Table<Pet>().Where(x => x.Id == petId).FirstOrDefaultAsync();
            return returnValue.Result;
        }

        public List<Pet> GetPetsAsync()
        {
            var returnValue = _db.Table<Pet>().ToListAsync();
            return returnValue.Result;
        }

        public bool AddPetAsync(Pet pet)
        {
            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Started");
            bool isSuccess = false;
            try
            {
                var inserted = _db.InsertAsync(pet).Result;
                if (inserted > 0)
                    isSuccess = true;
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
        public bool UpdatePetAsync(Pet pet)
        {
            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Started");
            bool isSuccess = false;
            try
            {
                var inserted = _db.UpdateAsync(pet);
                
                if (inserted.Result > 0)
                    isSuccess = true;
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

    }
}
