using System;
using System.Collections.Generic;
using System.Text;
using FurryFit.Repository;
using Xamarin.Forms.Internals;

namespace FurryFit.ViewModels.Pets
{
    [Preserve(AllMembers = true)]
    public class PetProfilesVM
    {
        public List<PetProfileViewModel> Pets;
        public PetProfilesVM()
        {
            Pets = new List<PetProfileViewModel>();
            PetRepository petRepository = new PetRepository();
            var _pets = petRepository.GetPetsAsync();
            foreach (var pet in _pets)
            {
                var _pet = new PetProfileViewModel();
                _pet.Id.Value = pet.Id;
                _pet.Name.Value = pet.Name;
                _pet.Breed.Value = pet.Breed;
                _pet.DOB.Value = pet.DOB;
                _pet.Sex.Value = pet.Sex;
                _pet.Neutered.Value = pet.Neutered;
                _pet.Weight.Value = pet.Weight;
                _pet.ExerciseGoal.Value = pet.ExerciseGoal;
                _pet.PetImagePath.Value = pet.DPPath;
                Pets.Add(_pet);
            }
            var _dummyPet = new PetProfileViewModel();
            _dummyPet.Id.Value = -999;
            _dummyPet.PetImagePath.Value = "furryfiticon.png";
            Pets.Add(_dummyPet);
        }
    }
}
