using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using FurryFit.Validations;
using FurryFit.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Internals;


namespace FurryFit.ViewModels.Pets
{
    [Preserve(AllMembers = true)]
    public class PetProfileViewModel : ExtendedBindableObject
    {
        public PetProfileViewModel()
        {
            _petName = new ValidatableObject<string>();
            _petBreed= new ValidatableObject<string>();
            _petDOB= new ValidatableObject<DateTime>();
            _petSex = new ValidatableObject<string>();
            _petNeutered= new ValidatableObject<string>();
            _petWeight= new ValidatableObject<int>();
            _petExerciseGoal= new ValidatableObject<int>();
            _petImagePath = new ValidatableObject<string>();
            _petDOB.Value=DateTime.Now;
            _petWeight.Value = 9;
            _petImagePath.Value = string.Empty;
            AddValidations();
        }

        private ValidatableObject<string> _petName;
        private ValidatableObject<string> _petBreed;
        private ValidatableObject<DateTime> _petDOB;
        private ValidatableObject<string> _petSex;
        private ValidatableObject<string> _petNeutered;
        private ValidatableObject<int> _petWeight;
        private ValidatableObject<int> _petExerciseGoal;
        private ValidatableObject<string> _petImagePath; 

        public ValidatableObject<int> ExerciseGoal
        {
            get
            {
                return _petExerciseGoal;
            }
            set
            {
                _petExerciseGoal = value;

                RaisePropertyChanged(() => ExerciseGoal);
            }
        }

        public ValidatableObject<string> PetImagePath
        {
            get
            {
                return _petImagePath;
            }
            set
            {
                _petImagePath = value;

                RaisePropertyChanged(() => PetImagePath);
            }
        }

        public ValidatableObject<int> Weight
        {
            get
            {
                return _petWeight;
            }
            set
            {
                _petWeight = value;
                RaisePropertyChanged(() => Weight);
            }
        }




        public ValidatableObject<DateTime> DOB
        {
            get
            {
                return _petDOB;
            }
            set
            {
                _petDOB = value;
                RaisePropertyChanged(() => DOB);
            }
        }

        public ValidatableObject<string> Breed
        {
            get
            {
                return _petBreed;
            }
            set
            {
                _petBreed = value;
                RaisePropertyChanged(()=> Breed);
            }
        }

        public ValidatableObject<string> Sex
        {
            get
            {
                return _petSex;
            }
            set
            {
                _petSex = value;
                RaisePropertyChanged(() => Sex);
            }
        }

        public ValidatableObject<string> Neutered
        {
            get
            {
                return _petNeutered;
            }
            set
            {
                _petNeutered = value;
                RaisePropertyChanged(() => Neutered);
            }
        }

        public ValidatableObject<string> Name {
            get
            { 
                return _petName; 

            }
            set
            {
                _petName = value;
                RaisePropertyChanged(()=>Name);
                //_petName.Validate();
            }
        }

        public ICommand ValidatePetName => new Command(() => _petName.Validate());
        public ICommand ValidatePetNeutered => new Command(() => _petNeutered.Validate());
        public ICommand ValidatePetSex => new Command(() => _petSex.Validate());
        public ICommand ValidatePetBreed => new Command(() => _petBreed.Validate());
        public ICommand ValidatePetDOB => new Command(() => _petDOB.Validate());
        public ICommand ValidatePetWeight => new Command(() => _petWeight.Validate());
        public ICommand ValidatePetExerciseGoal => new Command(() => _petExerciseGoal.Validate());
        public ICommand SaveCommand => new Command(() => Save());


        protected void Save()
        {
            if (ValidateObject())
                App.Current.MainPage.DisplayAlert("Validation","All Ok","OK");
            else
            {
                App.Current.MainPage.DisplayAlert("Validation", "Errors during validation", "OK");
            }
        }


        private bool ValidateObject()
        {

            var boolPetName = _petName.Validate();
            var boolPetNeutered = _petNeutered.Validate();
            var boolPetSex = _petSex.Validate();
            var boolPetBreed = _petBreed.Validate();
            var boolPetDOB = _petDOB.Validate();
            var boolPetWeight = _petWeight.Validate();
            var boolPetExerciseGoal = _petExerciseGoal.Validate();
            return boolPetName && boolPetNeutered && boolPetSex && boolPetBreed && boolPetDOB && boolPetWeight &&
                   boolPetExerciseGoal;

        }




    private void AddValidations()
        {
            _petName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Pet Name" });
            _petBreed.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "Select Pet's Breed"});
            _petSex.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Select Pet's Gender" });
            _petNeutered.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Is your pet Neutered/Spayed" });
            //_petDOB.Validations.Add(new IsNotNullOrEmptyRule<DateTime> { ValidationMessage = "Enter your Pet's Date of Birth" });
            _petWeight.Validations.Add(new IsAValidNumber<int> { ValidationMessage = "Enter valid weight" });
            _petWeight.Validations.Add(new IsNumberNotGreaterThanZero<int> { ValidationMessage = "Enter your pet's weight" });
            _petExerciseGoal.Validations.Add(new IsNumberNotGreaterThanZero<int> { ValidationMessage = "Enter your pet's Exercise Goal" });
            _petExerciseGoal.Validations.Add(new IsAValidNumber<int> { ValidationMessage = "Enter valid Exercise Goal" });
            _petDOB.Validations.Add((new IsNotFutureDate<DateTime>{ValidationMessage = "Date of Birth cannot be in future"}));

        }

    }
}
