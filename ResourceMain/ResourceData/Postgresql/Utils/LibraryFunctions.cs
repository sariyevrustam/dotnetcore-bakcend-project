namespace ResourceData.Postgresql.Utils
{
    public static class LibraryFunctions
    {
        public const string database_schema = "\"LibraResource\".";        
        public const string fn_resource_get = database_schema + "fn_resource_get";
        public const string fn_resource_get_all = database_schema + "fn_resource_get_all";
        public const string fn_resource_add = database_schema + "fn_resource_add";
        public const string fn_resource_edit = database_schema + "fn_resource_edit";
        public const string fn_resource_delete = database_schema + "fn_resource_delete";
        public const string fn_resource_check_basket = database_schema + "fn_resource_check_basket";
        public const string fn_resource_check_basket_resource_by_inventor_no = database_schema + "fn_resource_check_basket_resource_by_inventor_no";
        public const string fn_resource_double_check_basket_resources = database_schema + "fn_resource_double_check_basket_resources";
        public const string fn_resource_get_by_inventar_number = database_schema + "fn_resource_get_by_inventar_number";
    }
}
