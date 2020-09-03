using System;
using System.Collections.Generic;
using System.Text;

namespace FurryFit.Models.PetProfile
{
    public class PetAdditionalInfo: BaseModel
    {
        public string Insurer { get; set; }
        public string PolicyNumber { get; set; }
        public string InsurerContactNumber { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public string Vet { get; set; }
        public string VetContactNumber { get; set; }
        public string ChipNumber { get; set; }
        public int PetId { get; set; }

    }

    public class PetKennelClub : BaseModel
    {
        public string KennelClubName { get; set; }
        public string KennelRegistrationNumber { get; set; }
        public string KennelContactNumber { get; set; }
        public int PetId { get; set; }
    }
}
