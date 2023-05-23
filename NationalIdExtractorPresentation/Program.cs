using NationalIdExtraction;
using NationalIdExtraction.Providers;
using NationalIdExtractorPresentation;

//using Default Resource Provider
Console.WriteLine(new NationalIdExtractor().Extract("31011202101545"));
Console.WriteLine();

//using custome Resource provider
Console.WriteLine(new NationalIdExtractor(new NationalIdResourcesArabicProvider()).Extract("31013202101545", ignoreLegalAge:true, legalAge:15));