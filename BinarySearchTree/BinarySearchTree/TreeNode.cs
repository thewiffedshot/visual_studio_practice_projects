using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class TreeNode
    {
	    public object value { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public uint depth { get; set; }

        public TreeNode(object _value)
        {
            value = _value;
        }
    }
}
