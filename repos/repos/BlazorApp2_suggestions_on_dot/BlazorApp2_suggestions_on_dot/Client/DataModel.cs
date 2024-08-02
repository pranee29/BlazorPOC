namespace BlazorApp2_suggestions_on_dot.Client
{
    public class DataModel
    {
        public Guid id { get; set; }
        public Guid pid { get; set; }
        public string desc { get; set; }
        public string type { get; set; }
        public string sub_type { get; set; }
        public string name { get; set; }

        public IEnumerable<DataModel> data { get; set; } = new HashSet<DataModel>();

    }


}
