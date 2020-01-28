namespace ResourceData.Postgresql.Utils
{
    public static class LibraryFunctions
    {
        public const string database_schema = "\"LibraResource\".";        
        public const string fn_resource_get = database_schema + "fn_resource_get";
        public const string fn_resource_get_all = database_schema + "fn_resource_get_all";
        public const string fn_resource_get_by_category = database_schema + "fn_resource_get_by_category";
        public const string fn_resource_get_all_by_category = database_schema + "fn_resource_get_all_by_category";
        public const string fn_resource_add = database_schema + "fn_resource_add";
        public const string fn_resource_edit = database_schema + "fn_resource_edit";
        public const string fn_resource_delete = database_schema + "fn_resource_delete";
        public const string fn_resource_check_basket = database_schema + "fn_resource_check_basket";
        public const string fn_resource_check_basket_resource_by_inventor_no = database_schema + "fn_resource_check_basket_resource_by_inventor_no";
        public const string fn_resource_double_check_basket_resources = database_schema + "fn_resource_double_check_basket_resources";
        public const string fn_resource_get_by_inventar_number = database_schema + "fn_resource_get_by_inventar_number";
        public const string fn_resource_get_available_resource_copy_count = database_schema + "fn_resource_get_available_resource_copy_count";
        public const string fn_resource_author_search = database_schema + "fn_resource_author_search";
        public const string fn_resource_return = database_schema + "fn_resource_return";
        public const string fn_category_get_all = database_schema + "fn_category_get_all";
        public const string fn_publishing_house_get_all = database_schema + "fn_publishing_house_get_all";
        public const string fn_language_get_all = database_schema + "fn_language_get_all";
        public const string fn_resource_usage_location_statuses_get_all = database_schema + "fn_resource_usage_location_statuses_get_all";
        public const string fn_resource_type_get_all = database_schema + "fn_resource_type_get_all";
    }
}
