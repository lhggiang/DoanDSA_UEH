using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<Province> Provinces = new List<Province>();
        Graph g = new Graph();
        private void Form1_Load(object sender, EventArgs e)
        {
            Province haGiang = new Province("Hà Giang", "A", 85, 140);
            Province caoBang = new Province("Cao Bằng", "B", 225, 140);
            Province tuyenQuang= new Province("Tuyên Quang", "C", 125, 220);
            Province phuTho = new Province("Phú Thọ", "D", 113, 325); 
            Province haNoi = new Province("Hà Nội", "E", 192, 370);
            Province namDinh = new Province("Nam Định", "F",245, 455);
            Province haiPhong = new Province("Hải Phòng", "G", 290, 395);
            Province quangNinh = new Province("Quảng Ninh", "H",359, 351);
            Province langSon = new Province("Lạng Sơn", "I", 283, 260);
            Province banKan = new Province("Bắc Kạn", "K", 194, 205);
            Province bacGiang = new Province("Bắc Giang", "A",275, 321);

            Provinces.Add(haGiang);
            Provinces.Add(caoBang);
            Provinces.Add(tuyenQuang);
            Provinces.Add(phuTho);
            Provinces.Add(haNoi);
            Provinces.Add(namDinh);
            Provinces.Add(haiPhong);
            Provinces.Add(quangNinh);
            Provinces.Add(langSon); 
            Provinces.Add(banKan);
            Provinces.Add(bacGiang);

            cbSource.Items.Add(haGiang.provinceName);
            cbSource.Items.Add(caoBang.provinceName);
            cbSource.Items.Add(tuyenQuang.provinceName);
            cbSource.Items.Add(phuTho.provinceName);
            cbSource.Items.Add(haNoi.provinceName);
            cbSource.Items.Add(namDinh.provinceName );
            cbSource.Items.Add(haiPhong.provinceName);
            cbSource.Items.Add(quangNinh.provinceName);
            cbSource.Items.Add(langSon.provinceName); 
            cbSource.Items.Add(banKan.provinceName);
            cbSource.Items.Add(bacGiang.provinceName);

            cbDestination.Items.Add(haGiang.provinceName);
            cbDestination.Items.Add(caoBang.provinceName);
            cbDestination.Items.Add(tuyenQuang.provinceName);
            cbDestination.Items.Add(phuTho.provinceName);
            cbDestination.Items.Add(haNoi.provinceName);
            cbDestination.Items.Add(namDinh.provinceName);
            cbDestination.Items.Add(haiPhong.provinceName);
            cbDestination.Items.Add(quangNinh.provinceName);
            cbDestination.Items.Add(langSon.provinceName);
            cbDestination.Items.Add(banKan.provinceName);
            cbDestination.Items.Add(bacGiang.provinceName);

            Graphics graph = southMap.CreateGraphics();
            for (int i = 0; i < Provinces.Count; i++)
            {
                lvListProvinces.Items.Add(Provinces[i].getVerticesName());
                lvListProvinces.Items[i].SubItems.Add(Provinces[i].getName());
                g.listPoints.Add(Provinces[i].getPoint());
                g.AddVertices(Provinces[i].getName());
            }

            g.InsertEdge("Hà Giang", "Cao Bằng", 136);
            g.InsertEdge("Cao Bằng", "Lạng Sơn", 95);
            g.InsertEdge("Lạng Sơn", "Bắc Giang", 62);
            g.InsertEdge("Bắc Giang", "Quảng Ninh", 76);
            g.InsertEdge("Quảng Ninh", "Hải Phòng", 77);
            g.InsertEdge("Hải Phòng", "Nam Định", 77); 
            g.InsertEdge("Nam Định", "Hà Nội", 90);
            g.InsertEdge("Hà Nội", "Hải Phòng", 82);
            g.InsertEdge("Bắc Giang", "Hà Nội", 90); 
            g.InsertEdge("Hà Nội", "Bắc Kạn", 70);
            g.InsertEdge("Hà Nội", "Phú Thọ", 136);
            g.InsertEdge("Phú Thọ", "Tuyên Quang", 101);
            g.InsertEdge("Tuyên Quang", "Hà Giang", 76);
            g.InsertEdge("Bắc Kạn", "Hà Giang", 109);
            g.InsertEdge("Bắc Kạn", "Tuyên Quang", 60);
            g.InsertEdge("Bắc Kạn", "Cao Bằng", 53);
            g.InsertEdge("Bắc Kạn", "Phú Thọ", 134);
            g.InsertEdge("Bắc Kạn", "Lạng Sơn", 92);

        }
        //Vẽ bản đồ ra Panel
        private void southMap_Paint(object creator, PaintEventArgs e)
        {
            Graphics graph = southMap.CreateGraphics();
            for (int i = 0; i < Provinces.Count; i++)
            {
                SolidBrush brush = new SolidBrush(Color.SeaGreen);
                Brush pointName = new SolidBrush(Color.White);
                graph.FillEllipse(brush, Provinces[i].getPoint().X - 3, Provinces[i].getPoint().Y - 2, 18, 18);
                graph.DrawString(Provinces[i].getVerticesName(), new Font("Arial", 8), pointName, Provinces[i].getPoint().X, Provinces[i].getPoint().Y);
            }
            DrawLine();
        }
        private void DrawLine() 
        {
            DrawLine("Hà Giang", "Cao Bằng");
            DrawLine("Cao Bằng", "Lạng Sơn");
            DrawLine("Lạng Sơn", "Bắc Giang");
            DrawLine("Bắc Giang", "Quảng Ninh");
            DrawLine("Quảng Ninh", "Hải Phòng");
            DrawLine("Hải Phòng", "Nam Định");
            DrawLine("Nam Định", "Hà Nội");
            DrawLine("Hà Nội", "Hải Phòng");
            DrawLine("Bắc Giang", "Hà Nội");
            DrawLine("Hà Nội", "Bắc Kạn");
            DrawLine("Hà Nội", "Phú Thọ");
            DrawLine("Phú Thọ", "Tuyên Quang");
            DrawLine("Tuyên Quang", "Hà Giang");
            DrawLine("Bắc Kạn", "Hà Giang");
            DrawLine("Bắc Kạn", "Tuyên Quang");
            DrawLine("Bắc Kạn", "Cao Bằng");
            DrawLine("Bắc Kạn", "Phú Thọ");
            DrawLine("Bắc Kạn", "Lạng Sơn");
        }
        private void DrawLine(string a, string b)
        {
            Graphics graph = southMap.CreateGraphics();
            int x = g.GetIndex(a);
            int y = g.GetIndex(b);
            Pen p = new Pen(Color.Black, 2);
            Point point1 = new Point(g.listPoints[x].X, g.listPoints[x].Y);
            Point point2 = new Point(g.listPoints[y].X, g.listPoints[y].Y);
            graph.DrawLine(p, point1, point2);
            graph.DrawString($"{g.adjacency[x, y]}", new Font("Fira Code", 10), Brushes.Black, new Point((point1.X + point2.X) / 2 - 8, (point1.Y + point2.Y) / 2 + 8));
        }
        private void cbSource_SelectedIndexChanged(object creator, EventArgs e)
        {
            if (cbSource.SelectedIndex != -1 && cbDestination.SelectedIndex != -1)
            {
                southMap.Controls.Clear();
                southMap.Refresh();
                DrawLine();
                g.pathIndex.Clear();
                tbKM.Clear();
                tbLiter.Clear();
                tbCost.Clear();
                tbPath.Clear();
                g.findPaths(cbSource.SelectedItem.ToString(), cbDestination.SelectedIndex.ToString(), tbKM, tbLiter, tbCost, tbPath);
                for (int i = 0; i < g.pathIndex.Count - 1; i++)
                {
                    DrawPathLine(i);
                }
            }
            if (cbSource.SelectedIndex == cbDestination.SelectedIndex)
            {
                MessageBox.Show("Unresponsive\n Starting point must not be the same as destination !", "Notify!");
            }
        }
        private void cbDestination_SelectedIndexChanged(object creator, EventArgs e)
        {
            if (cbSource.SelectedIndex != -1 && cbDestination.SelectedIndex != -1)
            {
                southMap.Controls.Clear();
                southMap.Refresh();
                DrawLine();
                g.pathIndex.Clear();
                tbKM.Clear();
                tbLiter.Clear();
                tbCost.Clear();
                tbPath.Clear();
                g.findPaths(cbSource.SelectedItem.ToString(), cbDestination.SelectedIndex.ToString(), tbKM, tbLiter, tbCost, tbPath);
                for (int i = 0; i < g.pathIndex.Count - 1; i++)
                {
                    DrawPathLine(i);
                }
            }
            if (cbSource.SelectedIndex == cbDestination.SelectedIndex)
            {
                MessageBox.Show("Unresponsive\n Starting point must not be the same as destination !", "Notify!");
            }
        }
        private void DrawPathLine(int i)
        {
            Graphics graph = southMap.CreateGraphics();
            Pen p = new Pen(Color.Aqua, 2);
            Point point1 = new Point(g.pathIndex[i].X, g.pathIndex[i].Y);
            Point point2 = new Point(g.pathIndex[i + 1].X, g.pathIndex[i + 1].Y);
            graph.DrawLine(p, point1, point2);
        }

        
    }
}
