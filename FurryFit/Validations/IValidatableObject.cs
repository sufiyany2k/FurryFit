using System;
using System.Collections.Generic;
using System.Text;

namespace FurryFit.Validations
{
    public interface IValidatableObject
    {
        bool IsValid { get; set; }

    }
}
