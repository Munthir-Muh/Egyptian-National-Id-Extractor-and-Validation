using System;
using System.Collections.Generic;
using System.Text;
using NationalIdExtraction;
using NationalIdExtraction.Enums;

namespace NationalIdExtraction.Providers
{
    public class NationalIdResourcesDefaultProvider : INationalIdResourceProvider
    {
        private static readonly Dictionary<int, string> _governorates = new Dictionary<int, string>()
        {
            { 1, " Cairo" },
            { 2, " Alexandria" },
            { 3, " Port Said" },
            { 4, " Suez" },
            { 11, " Damietta" },
            { 12, " Dakahlia" },
            { 13, " Ash Sharqia" },
            { 14, " Kaliobeya" },
            { 15, " Kafr El - Sheikh" },
            { 16, " Gharbia" },
            { 17, " Monoufia" },
            { 18, " El Beheira" },
            { 19, " Ismailia" },
            { 21, " Giza" },
            { 22, " Beni Suef" },
            { 23, " Fayoum" },
            { 24, " El Menia" },
            { 25, " Assiut" },
            { 26, " Sohag" },
            { 27, " Qena" },
            { 28, " Aswan" },
            { 29, " Luxor" },
            { 31, " Red Sea" },
            { 32, " New Valley" },
            { 33, " Matrouh" },
            { 34, " North Sinai" },
            { 35, " South Sinai" },
            { 88, " Foreign" }
        };
        public string GetRelatedValidationError(NationalIdValidationMessages validationMessageType)
        {
            switch (validationMessageType)
            {
                case NationalIdValidationMessages.InvalidCentury:
                    return "Century is not in a valid foramte";

                case NationalIdValidationMessages.InvalidYearOfBirth:
                    return "Year of birth is not in a valid formate";

                case NationalIdValidationMessages.InvalidBirthDate:
                    return "Birth date foramte is not valid";

                case NationalIdValidationMessages.InvalidGovernorate:
                    return "Governerate code in not valid";

                default:
                    return "the entered national Id is not in a correct formate";
            }
        }

        public bool TryGetGovernorate(int governorateId, out string governorateName)
        {
            return _governorates.TryGetValue(governorateId, out governorateName);
        }
    }
}
