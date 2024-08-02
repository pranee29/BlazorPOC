using System;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static BlazorApp2_suggestions_on_dot.Client.DataModel;

namespace BlazorApp2_suggestions_on_dot.Client

{
    public class functionality
    {
        Dictionary<Guid, TreeItemData> dict = new Dictionary<Guid, TreeItemData>();
        private HashSet<TreeItemData> TreeItems = new HashSet<TreeItemData>();

        public IEnumerable<DataModel> data { get; set; } = new HashSet<DataModel>();

        public void example(IEnumerable<DataModel> s)
        {
            data = s;
        }
        public class TreeItemData
        {
            public Guid id { get; set; }

            public string Title { get; set; }

            public bool IsExpanded { get; set; }

            public HashSet<TreeItemData> TreeItems { get; set; }

            public TreeItemData(string title)
            {
                Title = title;
            }
        }

        public void addtodict(IEnumerable<DataModel> data)
        {
            dict = new Dictionary<Guid, TreeItemData>();
            dict[Guid.Empty] = new TreeItemData("NSL") { id = Guid.Empty, IsExpanded = false, TreeItems = new() };
            TreeItems.Add(dict[Guid.Empty]);
            foreach(var node in data)
            {
                dict[node.id] = new TreeItemData(node.name) { id = node.id, IsExpanded = false, TreeItems = new() };
            }
            foreach(var node in data){
                dict[node.pid].TreeItems.Add(dict[node.id]);
            }
        }

        public void ChangePropertyValue(TreeItemData s)
        {

            Console.WriteLine(dict[s.id].Title);
            foreach (var ele in dict[s.id].TreeItems)
            {
                Console.WriteLine(ele.Title);
            }
        }
        public Dictionary<Guid, TreeItemData> get_dict()
        {
            return dict;
        }
        public HashSet<TreeItemData> get_TreeItems()
        {
            return TreeItems;
        }
    }
}
