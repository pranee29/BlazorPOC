namespace BlazorApp2_syncfusion.Client
{
    public class DataModel
    {
        public string id { get; set; }
        public string pid { get; set; }
        public string desc { get; set; }
        public string type { get; set; }
        public string sub_type { get; set; }
        public string name { get; set; }

        public IEnumerable<DataModel> data { get; set; } = new HashSet<DataModel>();

    }


}
