using System.Windows.Controls;

namespace CamViewer.Models
{
    public class NodeItem
    {
        private string _parentId = string.Empty;
        private string _id = string.Empty;
        private TreeViewItem _viewItem;

        public NodeItem(string id, TreeViewItem viewItem)
        {
            _id = id;
            _viewItem = viewItem;
            _viewItem.Uid = id;
        }

        public NodeItem(string parentId, string id, TreeViewItem viewItem)
        {
            _parentId = parentId;
            _id = id;
            _viewItem = viewItem;
            _viewItem.Uid = id;
        }

        public string ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public TreeViewItem ViewItem
        {
            get { return _viewItem; }
            set { _viewItem = value; }
        }
    }
}
