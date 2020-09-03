using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using FurryFit.Models.PetProfile;
using FurryFit.Repository;
using FurryFit.Validations;
using FurryFit.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FurryFit.ViewModels.Pets
{
    [Preserve(AllMembers = true)]
    public class PetKennelInfoVM: ExtendedBindableObject
    {
        public ValidatableObject<string> _kennelClubName;
        public ValidatableObject<string> _kennelRegistrationNumber;
        public ValidatableObject<string> _kennelContactNumber;
        public ValidatableObject<int> _petId;
        private bool _isBusy = false;
        private PetKennelClub petKennelClub;
        private ValidatableObject<int> _id;

        public PetKennelInfoVM(int petId)
        {
            petKennelClub = new PetKennelClub();
            _id = new ValidatableObject<int>();
            _petId = new ValidatableObject<int>();
            _kennelClubName = new ValidatableObject<string>();
            _kennelRegistrationNumber = new ValidatableObject<string>();
            _kennelContactNumber = new ValidatableObject<string>();
            _petId.Value = petId;
            AddValidations();
            PetAdditionalInfoRepository petAdditionalInfoRepository = new PetAdditionalInfoRepository();

            var petKennelInfo = petAdditionalInfoRepository.GetPetKennelInfoAsync(_petId.Value);
            if (petKennelInfo != null)
            {
                _kennelClubName.Value = petKennelInfo.KennelClubName;
                _kennelRegistrationNumber.Value = petKennelInfo.KennelRegistrationNumber;
                _kennelContactNumber.Value = petKennelInfo.KennelContactNumber;
                _id.Value = petKennelInfo.Id;
            }
        }

        private void AddValidations()
        {


        }
        public ValidatableObject<string> KennelClubName
        {
            get
            {
                return _kennelClubName;
            }
            set
            {
                _kennelClubName = value;

                RaisePropertyChanged(() => KennelClubName);
            }
        }
        public ValidatableObject<string> KennelRegistrationNumber
        {
            get
            {
                return _kennelRegistrationNumber;
            }
            set
            {
                _kennelRegistrationNumber = value;

                RaisePropertyChanged(() => KennelRegistrationNumber);
            }
        }
        public ValidatableObject<string> KennelContactNumber
        {
            get
            {
                return _kennelContactNumber;
            }
            set
            {
                _kennelContactNumber = value;

                RaisePropertyChanged(() => KennelContactNumber);
            }
        }
        public ValidatableObject<int> PetId
        {
            get
            {
                return _petId;
            }
            set
            {
                _petId = value;

                RaisePropertyChanged(() => PetId);
            }
        }

        public ValidatableObject<int> Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;

                RaisePropertyChanged(() => Id);
            }
        }
        private bool ValidateObject()
        {
            if (PetId.Value <= 0)
                return false;

            return true;
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }
        public ICommand SaveCommand => new Command(() => Save());

        protected async void Save()
        {
            IsBusy = true;
            try
            {

                if (ValidateObject())
                {
                    //await App.Current.MainPage.DisplayAlert("Validation", "All Ok", "OK");

                    PetAdditionalInfoRepository petAdditionalInfoRepository = new PetAdditionalInfoRepository();
                    petKennelClub.KennelClubName = KennelClubName.Value;
                    petKennelClub.KennelRegistrationNumber = KennelRegistrationNumber.Value;
                    petKennelClub.KennelContactNumber = KennelContactNumber.Value;
                    petKennelClub.PetId = PetId.Value;
                    petKennelClub.Id = Id.Value;



                    bool result = false;
                    if (Id.Value == null || Id.Value <= 0)
                    {
                        result = petAdditionalInfoRepository.AddPetKennelInfoAsync(petKennelClub);
                        Id.Value = petKennelClub.Id;
                    }
                    else if (Id.Value > 0)
                    {
                        petKennelClub.Id = Id.Value;
                        result = petAdditionalInfoRepository.UpdatePetKennelInfoAsync(petKennelClub);
                        //Id.Value = pet.Id;
                    }

                    if (result)
                        await App.Current.MainPage.DisplayAlert("Data Saved", "All Ok", "OK");
                }

                else
                {
                    await App.Current.MainPage.DisplayAlert("Validation", "Errors during validation", "OK");
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
