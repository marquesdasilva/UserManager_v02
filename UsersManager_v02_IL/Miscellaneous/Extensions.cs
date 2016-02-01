using System.Resources;
using System;

namespace UserManager_v02_IL.Miscellaneous
{
    public static class Extensions
    {
        public static string GetResourceValue(this ResourceManager resourceManager, string key, bool ignoreCase = true)
        {
            string value = string.Empty;

            try
            {
                StringComparison comparisonType = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

                // Get the resource value by keys
                value = resourceManager.GetString(key);

                // If the key is not found throw an exception to be logged
                // The return string will be string.Empty
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Key and value not found in the resource file");

            }
            catch (Exception ex)
            {
                var a = ex;
                //GlobalVars.LoggerHelper.LogException(ex, Common.SeverityLevel.Critical);
            }

            return value;
        }
    }
}
