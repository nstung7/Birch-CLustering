using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shared._2d
{
    public interface IClusterFeature
    {
        public int Count { get; }
        public Vector2 LS { get; }
        public Vector2 SS { get; }
        public float Radius { get; }
    }
    public class Node : IClusterFeature
    {
        private List<IClusterFeature> children;
        public Node()
        {
            children = new List<IClusterFeature>();
        }

        //-------------- Properties
        public int Count => children.Sum(c => c.Count);
        public Vector2 LS => children.Sum(c => c.LS);
        public Vector2 SS => children.Sum(c => c.SS);
        public List<IClusterFeature> Children => children;
        public float Radius => this.GetRadius();

        //----------------------- Public Methods
        public void Add(IClusterFeature clusterFeature) => children.Add(clusterFeature);
        public void AddRange(IEnumerable<IClusterFeature> clusterFeatures) => children.AddRange(clusterFeatures);

        //------------------- Private Methods
    }
    public class Leaf : IClusterFeature
    {
        private List<Vector2> entries;
        private Node parent;
        public Leaf(Node parent, Vector2 data)
        {
            entries = new List<Vector2>();
            entries.Add(data);
            this.parent = parent;
        }

        //-------------- Properties
        public int Count => entries.Count;
        public Vector2 LS => entries.Sum(c => c);
        public Vector2 SS => entries.Sum(c => c * c);
        public List<Vector2> Entries => entries;
        public Node Parent => parent;
        public float Radius => this.GetRadius();

        //---------------- Public Methods
        public void Add(Vector2 data) => entries.Add(data);
        public void UpdateParent(Node parent) => this.parent = parent;
        public float RadiusWithData(Vector2 data)
        {
            var ss = SS + data * data;
            var ls = LS + data;
            var n = Count + 1;

            var ts = ss - (ls * ls / n);
            var ms = n;

            return Vector2.SquareRoot(ts / ms).Length();
        }

        //---------------- Private Methods
    }
}
