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
        //tên tỉnh
        public string provinceName { get; set; }
        //tên điểm
        public string verticesName { get; set; }
        //tọa độ x,y
        public Point verticesLocation { get; set; }
        //hàm tạo
        public Province(string provinceName, string verticesName, int x, int y)
        {
            this.provinceName = provinceName;
            this.verticesName = verticesName;
            Point P = new Point(x, y);
            this.verticesLocation = P;

        }
    }
}
