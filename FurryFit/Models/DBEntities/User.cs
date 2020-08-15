using System;
using System.Collections.Generic;
using System.Text;

namespace FurryFit.Models.DBEntities
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredDateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public int AuthenticationTypeId { get; set; }
        public string AuthenticationId { get; set; }
        public string DisplayPicture { get; set; }
    }
}
