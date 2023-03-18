namespace adapters.repositories.table
{
    public class UrlMap
    {
        public static string AggregationUrl(string tableId) => $"/api/table/{tableId}/aggregation";
        public static string FindUrl(string tableId) => $"/api/table/{tableId}";
        public static string FindByIdUrl(string tableId, int rowId) => $"/api/table/{tableId}/{rowId}";
        public static string FindByIdAndDeleteUrl(string tableId, int rowId) => $"/api/table/{tableId}/{rowId}";
        public static string FindByIdAndUpdateUrl(string tableId, int rowId) => $"/api/table/{tableId}/{rowId}";
        public static string InsertUrl(string tableId) => $"/api/table/{tableId}";
        public static string InsertManyUrl(string tableId) => $"/api/table/{tableId}/insert";
        public static string UpdateManyUrl(string tableId) => $"/api/table/{tableId}";
        public static string DeleteUrl(string tableId, int[] rowId) => $"/api/table/{tableId}/{rowId}";
        public static string DeleteManyUrl(string tableId) => $"/api/table/{tableId}/delete";
    }
}