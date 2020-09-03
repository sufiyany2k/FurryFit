using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace FurryFit.Models.PetProfile
{
    public class Pet: BaseModel
    {

        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string Neutered { get; set; }
        public int Weight { get; set; }
        public int ExerciseGoal { get; set; }
        public string DPPath { get; set; }
    }
}
