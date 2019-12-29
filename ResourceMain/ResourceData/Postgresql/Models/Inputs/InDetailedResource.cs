namespace ResourceData.Postgresql.Models.Inputs
{
    public class InDetailedResource
    {
        public string ResourceName { get; set; }
        public string CategoryName { get; set; }
        public string Language { get; set; }
        public int PublishYear { get; set; }
        public string TypeName { get; set; }
        public string AuthorName { get; set; }
        public int TotalAvailable { get; set; }
    }
}
