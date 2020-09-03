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
    public class PetAdditionInfoVM: ExtendedBindableObject
    {

        public ValidatableObject<string> _insurer;
        public ValidatableObject<string> _policyNumber;
        public ValidatableObject<string> _insurerContactNumber;
        public ValidatableObject<string> _vet;
        public ValidatableObject<string> _vetContactNumber;
        public ValidatableObject<string> _chipNumber;
        public ValidatableObject<int> _petId;
        public ValidatableObject<DateTime> _policyExpiryDate;
        private bool _isBusy=false;
        private PetAdditionalInfo petAdditionalInfo;
        private ValidatableObject<int> _id;

        public PetAdditionInfoVM(int petId)
        {
            petAdditionalInfo= new PetAdditionalInfo();
            _id = new ValidatableObject<int>();
            _petId = new ValidatableObject<int>();
            _insurer = new ValidatableObject<string>();
            _policyNumber = new ValidatableObject<string>();
            _insurerContactNumber= new ValidatableObject<string>();
            _vet = new ValidatableObject<string>();
            _vetContactNumber = new ValidatableObject<string>();
            _chipNumber = new ValidatableObject<string>();
            _petId.Value = petId;
            _policyExpiryDate = new ValidatableObject<DateTime>();
            AddValidations();
            PetAdditionalInfoRepository petAdditionalInfoRepository = new PetAdditionalInfoRepository();

            var petAddInfo = petAdditionalInfoRepository.GetPetAddInfoAsync(_petId.Value);
            if (petAddInfo != null)
            {
                _insurer.Value = petAddInfo.Insurer;
                _policyNumber.Value = petAddInfo.PolicyNumber;
                _insurerContactNumber.Value = petAddInfo.InsurerContactNumber;
                _vet.Value = petAddInfo.Vet;
                _vetContactNumber.Value = petAddInfo.VetContactNumber;
                _chipNumber.Value = petAddInfo.ChipNumber;
                _id.Value = petAddInfo.Id;
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
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }
        public ValidatableObject<string> Insurer {
            get { return _insurer; }
            set { _insurer = value; RaisePropertyChanged(() => Insurer); }
        }
        public ValidatableObject<string> PolicyNumber
        {
            get { return _policyNumber; }
            set { _policyNumber = value; RaisePropertyChanged(() => PolicyNumber); }
        }
        public ValidatableObject<string> InsurerContactNumber
        {
            get { return _insurerContactNumber; }
            set { _insurerContactNumber = value; RaisePropertyChanged(() => InsurerContactNumber); }
        }
        public ValidatableObject<DateTime> PolicyExpiryDate
        {
            get { return _policyExpiryDate; }
            set { _policyExpiryDate = value; RaisePropertyChanged(() => PolicyExpiryDate); }
        }
        public ValidatableObject<string> Vet
        {
            get { return _vet; }
            set { _vet = value; RaisePropertyChanged(() => Vet); }
        }
        public ValidatableObject<string> VetContactNumber
        {
            get { return _vetContactNumber; }
            set { _vetContactNumber = value; RaisePropertyChanged(() => VetContactNumber); }
        }
        public ValidatableObject<string> ChipNumber
        {
            get { return _chipNumber; }
            set { _chipNumber = value; RaisePropertyChanged(() => ChipNumber); }
        }
        public ValidatableObject<int> PetId
        {
            get { return _petId; }
            set { _petId = value; RaisePropertyChanged(() => PetId); }
        }

        private void AddValidations()
        {


        }

        private bool ValidateObject()
        {
            if (PetId.Value <= 0)
                return false;

            return true;
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
                    petAdditionalInfo.Insurer = Insurer.Value;
                    petAdditionalInfo.PolicyNumber = PolicyNumber.Value;
                    petAdditionalInfo.InsurerContactNumber = InsurerContactNumber.Value;
                    petAdditionalInfo.PolicyExpiryDate = PolicyExpiryDate.Value;
                    petAdditionalInfo.Vet = Vet.Value;
                    petAdditionalInfo.VetContactNumber= VetContactNumber.Value;
                    petAdditionalInfo.ChipNumber = ChipNumber.Value;
                    petAdditionalInfo.PetId = PetId.Value;
                    petAdditionalInfo.Id = Id.Value;



                    bool result = false;
                    if (Id.Value == null || Id.Value <= 0)
                    {
                        result = petAdditionalInfoRepository.AddPetAddInfoAsync(petAdditionalInfo);
                        Id.Value = petAdditionalInfo.Id;
                    }
                    else if (Id.Value > 0)
                    {
                        petAdditionalInfo.Id = Id.Value;
                        result = petAdditionalInfoRepository.UpdatePetAddInfoAsync(petAdditionalInfo);
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
