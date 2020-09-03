using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    public class PetProfileViewModel : ExtendedBindableObject
    {
        //public List<Pet> pets { get; set; }
        public PetProfileViewModel()
        {
            _id = new ValidatableObject<int>();
            _petName = new ValidatableObject<string>();
            _petBreed= new ValidatableObject<string>();
            _petDOB= new ValidatableObject<DateTime>();
            _petSex = new ValidatableObject<string>();
            _petNeutered= new ValidatableObject<string>();
            _petWeight= new ValidatableObject<int>();
            _petExerciseGoal= new ValidatableObject<int>();
            _petImagePath = new ValidatableObject<string>();
            _petImageStream = new ValidatableObject<Stream>();
            _petDOB.Value=DateTime.Now;
            _petWeight.Value = 9;
            _isBusy = false;
            //_petImagePath.Value = string.Empty;
            pet = new Pet();
            //pets = GetPets();
            
            AddValidations();
        }

        private ValidatableObject<int> _id;
        private Pet pet;
        private ValidatableObject<string> _petName;
        private ValidatableObject<string> _petBreed;
        private ValidatableObject<DateTime> _petDOB;
        private ValidatableObject<string> _petSex;
        private ValidatableObject<string> _petNeutered;
        private ValidatableObject<int> _petWeight;
        private ValidatableObject<int> _petExerciseGoal;
        private ValidatableObject<string> _petImagePath;
        private ValidatableObject<Stream> _petImageStream;
        private bool _isBusy;
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
        public ValidatableObject<Stream> PetImageStream
        {
            get
            {
                return _petImageStream;
            }
            set
            {
                _petImageStream = value;

                RaisePropertyChanged(() => PetImageStream);
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


        public bool IsBusy
        {
            get { return _isBusy;}
            set
            {
                _isBusy = value;
                RaisePropertyChanged(()=> IsBusy);
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

        protected async void Save()
        {
            IsBusy = true;
            try
            {

                if (ValidateObject())
                {
                    await App.Current.MainPage.DisplayAlert("Validation", "All Ok", "OK");

                    PetRepository petRepository = new PetRepository();
                    pet.Name = Name.Value;
                    pet.Breed = Breed.Value;
                    pet.DOB = DOB.Value;
                    pet.Sex = Sex.Value;
                    pet.Neutered = Neutered.Value;
                    pet.Weight = Weight.Value;
                    pet.ExerciseGoal = ExerciseGoal.Value;

                    if (PetImagePath.Value != string.Empty)
                    {
                        CopyDPToApplicationFolder();
                        //pet.DisplayPicture = GetBytesFromImageStream(PetImageStream.Value);
                    }

                    pet.DPPath = PetImagePath.Value;
                    bool result = false;
                    if (Id.Value == null || Id.Value <= 0)
                    {
                        result = petRepository.AddPetAsync(pet);
                        Id.Value = pet.Id;
                    }
                    else if (Id.Value > 0)
                    {
                        pet.Id = Id.Value;
                        result = petRepository.UpdatePetAsync(pet);
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

        private List<Pet> GetPets()
        {
            PetRepository petRepository = new PetRepository();
            return petRepository.GetPetsAsync();
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

        private void CopyDPToApplicationFolder()
        {
            string fileName = Path.GetFileName(_petImagePath.Value);

            var dirToCreate = Path.Combine(App.imageCopyPath, "PetDPs");
            if (!Directory.Exists(dirToCreate))
            {
                Directory.CreateDirectory(dirToCreate);
            }
            string destFolder = Path.Combine(dirToCreate, fileName);
            if (!PetImagePath.Value.Equals(destFolder))
            {
                System.IO.File.Copy(PetImagePath.Value, destFolder, true);
                PetImagePath.Value = destFolder;
            }
        }


        private byte[] GetBytesFromImageStream(Stream stream)
        {
            try
            {
                byte[] imageByte;
                System.IO.FileStream fileStream = new FileStream(PetImagePath.Value, FileMode.Open);
                Stream imageStream = fileStream;
                BinaryReader br = new BinaryReader(imageStream, Encoding.Default, true);
                imageByte = br.ReadBytes((int)imageStream.Length);

                CopyDPToApplicationFolder();

                return imageByte;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private Stream GetImageStreamFromBytes(byte[] byteArray)
        {
            try
            {
                return new MemoryStream(byteArray);
            }
            catch (Exception e)
            {
                return null;
            }
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
