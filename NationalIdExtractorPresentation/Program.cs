using NationalIdExtraction;
using NationalIdExtraction.Providers;
using NationalIdExtractorPresentation;
using System.Reflection;

//using Default Resource Provider
Console.WriteLine(new NationalIdExtractor().Extract("25105091700094"));
Console.WriteLine();


//using custome Resource provider
Console.WriteLine(new NationalIdExtractor(new NationalIdResourcesArabicProvider()).Extract("27910260101607", ignoreLegalAge:true, legalAge:15));