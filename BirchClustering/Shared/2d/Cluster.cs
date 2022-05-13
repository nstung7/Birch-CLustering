using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shared._2d
{
    public class Cluster
    {
        public Vector2 Centroid { get; set; }
        public List<Vector2> Children { get; set; }
    }
}
