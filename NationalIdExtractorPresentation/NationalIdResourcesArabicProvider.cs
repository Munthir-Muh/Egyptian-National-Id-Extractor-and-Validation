using NationalIdExtraction;
using NationalIdExtraction.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalIdExtractorPresentation
{
    internal class NationalIdResourcesArabicProvider : INationalIdResourceProvider
    {
        private static readonly Dictionary<int, string> _governorates = new Dictionary<int, string>()
        {
             {1, "القاهرة"},
             {2, "الإسكندرية"},
             {3, "بورسعيد"},
             {4, "السويس"},
             {11, "دمياط"},
             {12, "الدقهلية"},
             {13, "الشرقية "},
             {14, "القليوبية"},
             {15,"كفر الشيخ"},
             {16, "الغربية"},
             {17, "المنوفية"},
             {18, "البحيرة"},
             {19, "الإسماعيلية"},
             {21, "الجيزة"},
             {22, "بني سويف"},
             {23, "الفيوم"},
             {24, "المنيا"},
             {25, "أسيوط"},
             {26, "سوهاج"},
             {27, "قنا"},
             {28, "أسوان"},
             {29, "الأقصر"},
             {31, "البحر الأحمر"},
             {32, "الوادي الجديد"},
             {33, "مطروح"},
             {34, "شمال سيناء"},
             {35, "جنوب سيناء"},
             {88, "أجنبي"}
        };
        public string GetRelatedValidationError(NationalIdValidationMessages validationMessageType)
        {
            switch (validationMessageType)
            {
                case NationalIdValidationMessages.InvalidCentury:
                    return "قرن الميلاد لم يتم ادخاله بشكل صحيح";

                case NationalIdValidationMessages.InvalidYearOfBirth:
                    return "سنة الميلاد لم يتم ادخالها بشكل صحيح";

                case NationalIdValidationMessages.InvalidBirthDate:
                    return "مكونة تاريخ الميلاد في الرقم القومي المدخل غير صحيحة";

                case NationalIdValidationMessages.InvalidGovernorate:
                    return "مكون محافظة الميلاد غير مدخل بشكل صحيح";

                default:
                    return "الرقم القومي المدخل غير صحيح";
            }
        }

        public bool TryGetGovernorate(int governorateId, out string? governorateName)
        {
            return _governorates.TryGetValue(governorateId, out governorateName);
        }
    }
}
