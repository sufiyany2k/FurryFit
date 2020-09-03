using System;
using System.Collections.Generic;
using System.Text;
using FurryFit.Models.PetProfile;
using SQLite;

namespace FurryFit.Repository
{
    public class PetAdditionalInfoRepository
    {
        private static SQLiteAsyncConnection _db;

        public PetAdditionalInfoRepository()
        {
            _db = App.Database.SqLiteAsyncConnection;
            _db.CreateTableAsync<Models.PetProfile.PetAdditionalInfo>().Wait();
            _db.CreateTableAsync<Models.PetProfile.PetKennelClub>().Wait();
        }

        public bool AddPetAddInfoAsync(PetAdditionalInfo petAdditionalInfo)
        {
            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Started");
            bool isSuccess = false;
            try
            {
                var inserted = _db.InsertAsync(petAdditionalInfo).Result;
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
        public PetAdditionalInfo GetPetAddInfoAsync(int petId)
        {
            var returnValue = _db.Table<PetAdditionalInfo>().Where(x=> x.PetId==petId).FirstOrDefaultAsync();
            return returnValue.Result;
        }
        public bool UpdatePetAddInfoAsync(PetAdditionalInfo petAdditionalInfo)
        {
            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Started");
            bool isSuccess = false;
            try
            {
                var updated = _db.UpdateAsync(petAdditionalInfo).Result;
                if (updated > 0)
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







        public bool AddPetKennelInfoAsync(PetKennelClub petKennelClub)
        {
            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Started");
            bool isSuccess = false;
            try
            {
                var inserted = _db.InsertAsync(petKennelClub).Result;
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
        public PetKennelClub GetPetKennelInfoAsync(int petId)
        {
            var returnValue = _db.Table<PetKennelClub>().Where(x => x.PetId == petId).FirstOrDefaultAsync();
            return returnValue.Result;
        }
        public bool UpdatePetKennelInfoAsync(PetKennelClub petKennelClub)
        {
            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Started");
            bool isSuccess = false;
            try
            {
                var updated = _db.UpdateAsync(petKennelClub).Result;
                if (updated > 0)
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
