using System;
using System.Linq;
using System.Collections.Generic;

namespace AshesToTree
{
    public class AshesToTree
    {
        public static INode[] GetTree(string []ashes, char delimiter)
        {
            List<string[]> splitList = ashes.Select(item => item.Split(delimiter)).ToList();
            return GetSubTree(splitList);
        }

        private static INode[] GetSubTree(IEnumerable<string[]> splitList)
        {
            var parentedSplitList = splitList.Where(item => item.Length > 1).ToList();
            var groups = parentedSplitList.GroupBy(split => split[0]);
            List<INode> parents = new List<INode>();
            foreach (var group in groups)
            {
                var parentNode = new ParentNode { Name = group.Key };

                foreach(INode childNode in GetSubTree(group.Select(s => s.Skip(1).ToArray())))
                {
                    parentNode.AddChild(childNode);
                }
            
                parents.Add(parentNode);

            }

            var unparentedSplitList = splitList.Where(item => item.Length == 1).SelectMany(item => item);
            foreach(string leaf in unparentedSplitList)
            {
                parents.Add(new LeafNode { Name = leaf });
            }
            return parents.ToArray();
        }
    }

    public interface INode
    {
        string Name { get; set; }
    } 

    public class ParentNode : INode
    {
        private List<INode> m_Children = new List<INode>();
        public IEnumerable<INode> Children { get => m_Children; } 
        public string Name { get; set; }

        public void AddChild(INode node) => m_Children.Add(node);
    }

    public class LeafNode : INode
    {
        public string Name { get; set; }
    }
}
