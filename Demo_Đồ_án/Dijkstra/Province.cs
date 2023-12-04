using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Province
    {
        public string provinceName { get; set; }
        public string verticesName { get; set; }
        public Point verticesLocation { get; set; }
        public Province(string provinceName, string verticesName, int x, int y)
        {
            this.provinceName = provinceName;
            this.verticesName = verticesName;
            Point P = new Point(x, y);
            this.verticesLocation = P;

        }
        public string getName()
        {
            return provinceName;
        }
        public string getVerticesName()
        {
            return verticesName;
        }
        public Point getPoint()
        {
            return verticesLocation;
        }
    }
}
