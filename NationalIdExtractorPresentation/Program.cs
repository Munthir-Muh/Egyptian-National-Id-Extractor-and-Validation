using NationalIdExtraction;
using NationalIdExtraction.Providers;
using NationalIdExtractorPresentation;

//using Default Resource Provider
Console.WriteLine(new NationalIdExtractor().Extract("31011208801846"));
Console.WriteLine();

//using custome Resource provider
Console.WriteLine(new NationalIdExtractor(new NationalIdResourcesArabicProvider()).Extract("310132001743", ignoreLegalAge:true, legalAge:15));