using System;
using System.Collections.Generic;
using System.Text;

namespace NationalIdExtraction.Extentions
{
    public static class ExtentionUtilities
    {
        public static PipeLinedObject<T> CreatePipeLineFor<T>(this T target)
        {
            return new PipeLinedObject<T>(target);
        }
    }

}
