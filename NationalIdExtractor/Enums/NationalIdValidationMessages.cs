using System;
using System.Collections.Generic;
using System.Text;

namespace NationalIdExtraction.Enums
{
    public enum NationalIdValidationMessages
    {
        InvalidProvidedNationalId = 0,
        InvalidCentury = 1,
        InvalidYearOfBirth = 2,
        InvalidBirthDate = 3,
        InvalidGovernorate = 4
    }
}
