using static CamViewer.Views.Config;

namespace CamViewer.Models
{
    public class NodeTag
    {
        private TypeNodeEnum type;
        private object _reference;

        public NodeTag(TypeNodeEnum typeNode, object reference)
        {
            type = typeNode;
            _reference = reference;
        }

        public TypeNodeEnum TypeNode
        {
            get => type;
            set => type = value;
        }

        public object Reference
        {
            get => _reference;
            set => _reference = value;
        }
    }
}