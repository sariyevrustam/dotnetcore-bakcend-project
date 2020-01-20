using System.Collections.Generic;

namespace ResourceData.Postgresql.Utils
{
    public static class LibraryErrorMessages
    {
        public static Dictionary<string, string> lib_resource_errors = new Dictionary<string, string>()
        {
            {"lib_resource_0000", "The resource was not found." },
            {"lib_resource_0001", "The resources were not found."},
            {"lib_resource_sys_0000", "Database is unaccessible." },
            {"lib_resource_sys_0001", "Authentication failed." },
            {"lib_resource_sys_0002", "Invalid refresh token." },
            {"lib_category_0001", "The categories were not found."},
            {"lib_publishing_house_0001", "The publishing_houses were not found."},
            {"lib_language_0001", "The languages were not found."},
            {"lib_usage_location_status_0001", "The usage location statuses were not found."}
        }; 

        public static string GetErrorMessage(string errorCode)
        {
            string errorMessage = "";

            if (errorCode.StartsWith("lib"))
            {
                errorMessage = lib_resource_errors[errorCode];                
            }
            else
            {
                errorMessage = lib_resource_errors["lib_resource_sys_0000"];
            }

            return errorMessage;            
        }
    }
}
    