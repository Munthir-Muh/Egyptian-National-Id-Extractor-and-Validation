using NationalIdExtraction.Enums;

namespace NationalIdExtraction
{
    public interface INationalIdResourceProvider
    {
        bool TryGetGovernorate(int governorateId, out string governorateName);
        string GetRelatedValidationError(NationalIdValidationMessages validationMessageType);
    }
}