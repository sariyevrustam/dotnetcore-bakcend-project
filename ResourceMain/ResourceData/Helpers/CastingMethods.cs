using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Outputs;
using System.Collections.Generic;

namespace ResourceData.Helpers
{
    public static class CastingMethods
    {
        public static Resource CastToResource(ItemResult itemResult)
        {
            return (Resource) itemResult.Item;
        }

        public static List<Resource> CastToResourceList(ItemResult itemResult)
        {
            return (List<Resource>) itemResult.Item;
        }
    }
}
