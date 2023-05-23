using System;
using System.Globalization;
using NationalIdExtraction.Enums;
using NationalIdExtraction.Extentions;
using NationalIdExtraction.Providers;

namespace NationalIdExtraction
{

    public sealed class NationalIdExtractor
    {
        private readonly INationalIdResourceProvider _resourceProvider;
        /// <summary>
        /// Create new instance using the default resource provider.
        /// </summary>
        public NationalIdExtractor() : this(new NationalIdResourcesDefaultProvider()) { }
        /// <summary>
        /// Create new instance with providing custom resource provider.
        /// </summary>
        /// <param name="resourceProvider">custom resource provider that implement <see cref="INationalIdResourceProvider"/> </param>
        public NationalIdExtractor(INationalIdResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
        }
        /// <summary>
        /// Preform Extraction and validation to personal data from provided national id and return the extraction result
        /// </summary>
        /// <param name="nationalIdNo">underlying national id number</param>
        /// <param name="ignoreLegalAge">if set false then it will validate if the national id holder reach the legal age or not, the default value is true</param>
        /// <param name="legalAge">the legal age at which a person should issue national Id</param>
        /// <returns>Extraction Result that contains the extracted data any validation errors if any.</returns>
        public NationalIdExtrationResult Extract(string nationalIdNo, bool ignoreLegalAge = true, int legalAge = 16)
        {
            var extractionResult = new NationalIdExtrationResult(nationalIdNo);

            return extractionResult.CreatePipeLineFor()
                .Pipe(CheckProvidedNationalId)
                .Pipe(er => ExtractBirthDate(er, ignoreLegalAge, legalAge))
                .Pipe(ExtractGovernorate)
                .Pipe(ExtractGender)
                .Close();
        }

        private void CheckProvidedNationalId(NationalIdExtrationResult extractionResult)
        {
            if (extractionResult.NationalId?.Length != 14 ||
                !long.TryParse(extractionResult.NationalId, out _) ||
                extractionResult.NationalId.EndsWith("0"))
            {
                extractionResult.AddValidationErrors(_resourceProvider.
                    GetRelatedValidationError(NationalIdValidationMessages.InvalidProvidedNationalId));
            }
        }
        private void ExtractBirthDate(NationalIdExtrationResult extractionResult, bool ignoreLegalAge, int legalAge)
        {
            if (extractionResult.IsValid)
            {

                if (!TryParseCentury(extractionResult.NationalId.Substring(0, 1), out int generation))
                {
                    extractionResult.AddValidationErrors(_resourceProvider.
                        GetRelatedValidationError(NationalIdValidationMessages.InvalidCentury));
                    return;
                }
                if (!TryParseYear(generation, extractionResult.NationalId.Substring(1, 2),
                    out int yearOfBirth, ignoreLegalAge, legalAge))
                {
                    extractionResult.AddValidationErrors(_resourceProvider.
                        GetRelatedValidationError(NationalIdValidationMessages.InvalidYearOfBirth));
                    return;
                }
                var monthOfBirth = int.Parse(extractionResult.NationalId.Substring(3, 2));
                var dayOfBirth = int.Parse(extractionResult.NationalId.Substring(5, 2));

                if (!DateTime.TryParse($"{dayOfBirth}/{monthOfBirth}/{yearOfBirth}",
                    new DateTimeFormatInfo() { ShortDatePattern = "dd/MM/yyyy" }, DateTimeStyles.AssumeLocal, out DateTime dateOfBirth))
                {
                    extractionResult.AddValidationErrors(_resourceProvider.
                        GetRelatedValidationError(NationalIdValidationMessages.InvalidBirthDate));
                    return;
                }
                extractionResult.DateOfBirth = dateOfBirth;
            }
        }
        private void ExtractGovernorate(NationalIdExtrationResult extractionResult)
        {
            if (extractionResult.IsValid)
            {
                var governerate = int.Parse(extractionResult.NationalId.Substring(7, 2));
                if (!_resourceProvider.TryGetGovernorate(governerate, out var governorateName))
                {
                    extractionResult.AddValidationErrors(_resourceProvider.
                        GetRelatedValidationError(NationalIdValidationMessages.InvalidGovernorate));
                    return;
                }
                extractionResult.GovernorateOfBirth = governorateName;
            }
        }
        private void ExtractGender(NationalIdExtrationResult extractionResult)
        {
            if (extractionResult.IsValid)
            {
                if (int.Parse(extractionResult.NationalId.Substring(12, 1)) % 2 == 1)
                {
                    extractionResult.Gender = Gender.Male;
                    return;
                }
                extractionResult.Gender = Gender.Female;
            }
        }
        private static bool TryParseCentury(string stringGeneration, out int generation)
        {
            generation = int.Parse(stringGeneration);
            if (generation != 2 && generation != 3)
            {
                return false;
            }
            return true;
        }
        private static bool TryParseYear(int generation, string year, out int calenderYear, bool ignoreLegalAge, int legalAge)
        {
            calenderYear = int.Parse(generation == 2 ? $"19{year}" : $"20{year}");

            if (calenderYear > DateTime.Today.Year)
            {
                return false;
            }

            if (!ignoreLegalAge && generation == 3 && calenderYear > DateTime.Today.Year - legalAge)
            {
                return false;
            }
            return true;
        }
    }
}
