using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            /*Province binhPhuoc = new Province("Bình Phước", "A", 600, 440);
            Province saiGon = new Province("Sài Gòn", "B", 570, 550);
            Province tayNinh = new Province("Tây Ninh", "C", 500, 480);
            Province vungTau = new Province("Vũng Tàu", "D", 650, 580);
            Province tienGiang = new Province("Tiền Giang", "E", 500, 590);
            Province anGiang = new Province("An Giang", "F", 350, 590);
            Province hauGiang = new Province("Hậu Giang", "G", 420, 670);
            Province traVinh = new Province("Trà Vinh", "H", 530, 670);
            Province kienGiang = new Province("Kiên Giang", "I", 350, 660);
            Province caMau = new Province("Cà Mau", "K", 350, 750);*/
            Province binhPhuoc = new Province("Bình Phước", "A", 541, 65);
            Province saiGon = new Province("Sài Gòn", "B", 502, 164);
            Province tayNinh = new Province("Tây Ninh", "C", 431, 105);
            Province vungTau = new Province("Vũng Tàu", "D", 590, 198);
            Province tienGiang = new Province("Tiền Giang", "E", 432, 212);
            Province anGiang = new Province("An Giang", "F", 296, 210);
            Province hauGiang = new Province("Hậu Giang", "G", 348, 286);
            Province traVinh = new Province("Trà Vinh", "H", 462, 286);
            Province kienGiang = new Province("Kiên Giang", "I", 290, 286);
            Province caMau = new Province("Cà Mau", "K", 260, 345);
            Provinces.Add(binhPhuoc);
            Provinces.Add(saiGon);
            Provinces.Add(tayNinh);
            Provinces.Add(vungTau);
            Provinces.Add(tienGiang);
            Provinces.Add(anGiang);
            Provinces.Add(hauGiang);
            Provinces.Add(traVinh);
            Provinces.Add(kienGiang);
            Provinces.Add(caMau);
            cbSource.Items.Add("Bình Phước");
            cbSource.Items.Add("Sài Gòn");
            cbSource.Items.Add("Tây Ninh");
            cbSource.Items.Add("Vũng Tàu");
            cbSource.Items.Add("Tiền Giang");
            cbSource.Items.Add("An Giang");
            cbSource.Items.Add("Hậu Giang");
            cbSource.Items.Add("Trà Vinh");
            cbSource.Items.Add("Kiên Giang");
            cbSource.Items.Add("Cà Mau");
            cbDestination.Items.Add("Bình Phước");
            cbDestination.Items.Add("Sài Gòn");
            cbDestination.Items.Add("Tây Ninh");
            cbDestination.Items.Add("Vũng Tàu");
            cbDestination.Items.Add("Tiền Giang");
            cbDestination.Items.Add("An Giang");
            cbDestination.Items.Add("Hậu Giang");
            cbDestination.Items.Add("Trà Vinh");
            cbDestination.Items.Add("Kiên Giang");
            cbDestination.Items.Add("Cà Mau");
            Graphics graph = southMap.CreateGraphics();
            for (int i = 0; i < Provinces.Count; i++)
            {
                lvListProvinces.Items.Add(Provinces[i].getVerticesName());
                lvListProvinces.Items[i].SubItems.Add(Provinces[i].getName());
                g.listPoints.Add(Provinces[i].getPoint());
                g.AddVertices(Provinces[i].getName());
            }
            g.InsertEdge("Tây Ninh", "Bình Phước", 111);
            g.InsertEdge("Vũng Tàu", "Bình Phước", 182);
            g.InsertEdge("Sài Gòn", "Bình Phước", 124);
            g.InsertEdge("Vũng Tàu", "Sài Gòn", 98);
            g.InsertEdge("Tiền Giang", "Sài Gòn", 72);
            g.InsertEdge("An Giang", "Sài Gòn", 235);
            g.InsertEdge("Tây Ninh", "Sài Gòn", 92);
            g.InsertEdge("Trà Vinh", "Sài Gòn", 125);
            g.InsertEdge("Trà Vinh", "Cà Mau", 195);
            g.InsertEdge("Trà Vinh", "Hậu Giang", 124);
            g.InsertEdge("Tiền Giang", "An Giang", 174);
            g.InsertEdge("Trà Vinh", "Tiền Giang", 68);
            g.InsertEdge("An Giang", "Trà Vinh", 187);
            g.InsertEdge("Hậu Giang", "Cà Mau", 130);
            g.InsertEdge("Cà Mau", "Kiên Giang", 106);
            g.InsertEdge("An Giang", "Hậu Giang", 146);
            g.InsertEdge("An Giang", "Kiên Giang", 96);
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
            DrawLine("Tây Ninh", "Bình Phước");
            DrawLine("Vũng Tàu", "Bình Phước");
            DrawLine("Sài Gòn", "Bình Phước");
            DrawLine("Vũng Tàu", "Sài Gòn");
            DrawLine("Tiền Giang", "Sài Gòn");
            DrawLine("An Giang", "Sài Gòn");
            DrawLine("Tây Ninh", "Sài Gòn");
            DrawLine("Trà Vinh", "Sài Gòn");
            DrawLine("Trà Vinh", "Cà Mau");
            DrawLine("Trà Vinh", "Hậu Giang");
            DrawLine("Tiền Giang", "An Giang");
            DrawLine("Trà Vinh", "Tiền Giang");
            DrawLine("An Giang", "Trà Vinh");
            DrawLine("Hậu Giang", "Cà Mau");
            DrawLine("Cà Mau", "Kiên Giang");
            DrawLine("An Giang", "Hậu Giang");
            DrawLine("An Giang", "Kiên Giang");
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
