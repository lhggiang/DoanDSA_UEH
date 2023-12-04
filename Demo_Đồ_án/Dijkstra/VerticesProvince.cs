using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Vertex
    {
        public string nameVertices { get; private set; }
        public bool wasVisited { get; set; }
        public string previousVertices { get; set; }
        public double pathLenght { get; set; }
        public Vertex(string s)
        {
            this.nameVertices = s;
        }
    }
}
