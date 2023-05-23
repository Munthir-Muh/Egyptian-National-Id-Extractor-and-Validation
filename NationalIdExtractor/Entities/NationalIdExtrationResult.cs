using System.Reflection;
using System;
using NationalIdExtraction.Enums;
using System.Text;

namespace NationalIdExtraction
{
    public class NationalIdExtrationResult
    {
        public bool IsValid { get; private set; } = true;
        public string NationalId { get; internal set; }
        public DateTime? DateOfBirth { get; internal set; }
        public string GovernorateOfBirth { get; internal set; }
        public Gender Gender { get; internal set; }
        public string ValidationErrors { get; private set; }
        public NationalIdExtrationResult(string nationalId)
        {
            NationalId = nationalId;
        }
        internal void AddValidationErrors(string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                ValidationErrors = error;
                IsValid = false;
            }

        }

        public override string ToString()
        {
            var status = IsValid ? "Valid" : "Invalid";
            var validationErrorLine = IsValid ? string.Empty : $"Validation Error: {ValidationErrors}";

            return $"Provided National Id| {NationalId}\n\r{"Status", -20}| {status}\n\r{"Date Of Birth", -20}| {DateOfBirth}\n\r" +
                $"Governorate Of Birth| {GovernorateOfBirth}\n\r{"Gender", -20}| {Gender}\n\r{validationErrorLine}";
        }
    }
}