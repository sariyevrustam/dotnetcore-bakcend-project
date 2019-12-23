using Microsoft.AspNetCore.Mvc;
using ResourceData.Settings;

namespace ResourceApi.BaseControllerClasses
{
    public class LibraryControllerBase : ControllerBase
    {
        DbSettings dbSettings { get; }

        public LibraryControllerBase(DbSettings _dbSettings)
        {
            dbSettings = _dbSettings;
        }      
    }
}
