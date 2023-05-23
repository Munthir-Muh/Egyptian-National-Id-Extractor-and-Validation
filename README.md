# NationalIdExtractor
The <b>National Id Extraction</b> library helps to validate and extract data from national id like:
* Birth Date
* Governorate
* Gender

the validation is based on egyption national id segmentation that discribed in this <a href="https://ar.wikipedia.org/wiki/%D8%A8%D8%B7%D8%A7%D9%82%D8%A9_%D8%A7%D9%84%D8%B1%D9%82%D9%85_%D8%A7%D9%84%D9%82%D9%88%D9%85%D9%8A_%D8%A7%D9%84%D9%85%D8%B5%D8%B1%D9%8A%D8%A9">link</a>.

# Documentation:

  # NationalIdExtractor:
  The main class is <b>NationalIdExtractor</b> that can be instantiate as the following:
  * using the prameterless constractor, in this case it will use the default <b>INationalIdResourceProvider</b> implementation.
  * providing a custom <b>INationalIdResourceProvider</b> implementation.

  Then you can call <b>Extract</b> method and passing to it the national Id number you want to extract and validate.

  # INationalIdResourceProvider:
  this interface should be implemented if you want to customize the validation message (change language as an example) and the governorate or 
  you have this resources in a different proveder like (database or json file..etc).
  
  there is <b>NationalIdResourcesDefaultProvider</b> which is the default implementation that i have create it as an example and to be ready to use.
  
  # NationalIdExtractorPresentation:
  NationalIdExtractorPresentation is a console project to demonstrate how we can use this library using to senario :
  * using the default <b>INationalIdResourceProvider</b> implementation.
  * using custom <b>INationalIdResourceProvider</b> implementation which is <b>NationalIdResourcesArabicProvider</b> that have an arabic impelementation and you can do your own implementation to target a different sources with different langages.


If you have any suggestions to improve my code and techniques, please let me know. Your feedback would be highly appreciated.


