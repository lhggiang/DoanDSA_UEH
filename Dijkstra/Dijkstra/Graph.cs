using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra
{
    class Graph
    {
        private const int MaxCountVertices = 100;
        private const int INF = 99999;
        public int countOfVertices = 0;
        public int[,] adjacency;
        public List<int>[] adjacencyVertices;
        public Vertex[] vertices;
        public List<Point> listPoints = new List<Point>();
        public List<Point> pathIndex = new List<Point>();

        public Graph()
        {
            vertices = new Vertex[MaxCountVertices];
            adjacencyVertices = new List<int>[MaxCountVertices];
            for (int i = 0; i < MaxCountVertices; i++)
            {
                adjacencyVertices[i] = new List<int>();
            }
            adjacency = new int[MaxCountVertices, MaxCountVertices];
        }


        public void Dijkstra(string s)
        {
            for (int i = 0; i < countOfVertices; i++)
            {
                vertices[i].wasVisited = false;
                if (vertices[i].nameVertices == s)
                    vertices[i].pathLenght = 0;
                else
                    vertices[i].pathLenght = INF;
                vertices[i].previousVertices = "";
            }
            PriorityQueueForGraph distance_name = new PriorityQueueForGraph();
            distance_name.Enqueue(0, GetIndex(s));
            while (!distance_name.IsEmpty())
            {
                double kc = distance_name.GetDistanceFront();
                int vertices = distance_name.GetVerticesIndexFront();
                distance_name.Dequeue();
                if (this.vertices[vertices].wasVisited)
                {
                    continue;
                }
                this.vertices[vertices].wasVisited = true;
                foreach (int y in adjacencyVertices[vertices])
                {
                    double w = adjacency[y, vertices];
                    if (this.vertices[y].pathLenght > (this.vertices[vertices].pathLenght + w))
                    {
                        this.vertices[y].pathLenght = this.vertices[vertices].pathLenght + w;
                        distance_name.Enqueue(this.vertices[y].pathLenght, y);
                        this.vertices[y].previousVertices = this.vertices[vertices].nameVertices;
                    }
                }
            }
        }
        public void Dijkstra(string s, string t)
        {
            for (int i = 0; i < countOfVertices; i++)
            {
                vertices[i].wasVisited = false;
                if (vertices[i].nameVertices == s)
                    vertices[i].pathLenght = 0;
                else
                    vertices[i].pathLenght = INF;
                vertices[i].previousVertices = "";
            }
            PriorityQueueForGraph distance_name = new PriorityQueueForGraph();
            distance_name.Enqueue(0, GetIndex(s));
            while (!distance_name.IsEmpty())
            {
                double kc = distance_name.GetDistanceFront();
                int vertices = distance_name.GetVerticesIndexFront();
                distance_name.Dequeue();
                if (this.vertices[vertices].wasVisited)
                {
                    continue;
                }
                this.vertices[vertices].wasVisited = true;
                foreach (int y in adjacencyVertices[vertices])
                {
                    double w = adjacency[y, vertices];
                    if (this.vertices[y].pathLenght > (this.vertices[vertices].pathLenght + w))
                    {
                        this.vertices[y].pathLenght = this.vertices[vertices].pathLenght + w;
                        distance_name.Enqueue(this.vertices[y].pathLenght, y);
                        this.vertices[y].previousVertices = this.vertices[vertices].nameVertices;
                    }
                }
            }
            List<string> x = new List<string>();
            string k = t;
            while (true)
            {
                for (int i = 0; i < countOfVertices; i++)
                {
                    if (this.vertices[i].nameVertices == t)
                    {
                        x.Add(t);
                        if (t == s)
                        {
                            x.Reverse();
                            foreach (string l in x)
                            {
                                Console.Write(l + " ");
                            }
                            for (int j = 0; j < countOfVertices; j++)
                            {
                                if (vertices[j].nameVertices == k)
                                {
                                    Console.Write("\n" + this.vertices[j].pathLenght);
                                }
                            }
                            return;
                        }
                        t = this.vertices[i].previousVertices;
                        break;
                    }
                }
            }
        }
        public void findPaths(string source, string last, TextBox tbKM, TextBox tbLiter, TextBox tbCost, TextBox tbPath)
        {
            int s = GetIndex(source);
            Dijkstra(source);
            int v = Convert.ToInt32(last);
            {
                if (v != s)
                {
                    if (vertices[v].pathLenght == INF)
                    {
                        tbPath.Text += "\tNo path \n";
                    }
                    else
                    {
                        findPath(s, v, tbKM, tbLiter, tbCost, tbPath);
                    }
                }

            }
        }

        public void findPath(int s, int v, TextBox tbKM, TextBox tbLiter, TextBox tbCost, TextBox tbPath)
        {
            int i, u;
            int[] path = new int[countOfVertices];
            int km = 0;
            int count = 0;
            while (v != s)
            {
                count++;
                path[count] = v;
                u = GetIndex(vertices[v].previousVertices);
                km += adjacency[u, v];
                v = u;
            }
            double sl = km * 0.09;
            double sd = km * 2043;
            CultureInfo culture = new CultureInfo("vi-VN");
            string formattedAmount = string.Format(culture, "{0:#,##0.####} {1}", sd, "VNĐ");
            count++;
            if (count >= countOfVertices)
            {
                MessageBox.Show("Error");
            }
            path[count] = s;
            for (i = count; i >= 1; i--)
            {
                pathIndex.Add(listPoints[path[i]]);
                if (tbPath.Text == "")
                {
                    tbPath.Text += vertices[path[i]].nameVertices;

                }
                else
                {
                    tbPath.Text += " → " + vertices[path[i]].nameVertices;
                }
            }
            tbKM.Text = $"{km} KM";
            tbLiter.Text = $"{sl} liters";
            tbCost.Text = $"{formattedAmount}";
        }
        public void AddVertices(string s)
        {
            vertices[countOfVertices++] = new Vertex(s);
        }

        public void Print()
        {
            for (int i = 0; i < countOfVertices; i++)
            {
                Console.WriteLine(vertices[i].pathLenght);
            }
        }
        public int GetIndex(string s)
        {
            for (int i = 0; i < countOfVertices; i++)
            {
                if (s.Equals(vertices[i].nameVertices))
                    return i;
            }
            throw new System.InvalidOperationException("Invalid Vertex");
        }
        public void InsertEdge(string v1, string v2, int v3)
        {
            int i = GetIndex(v1);
            int j = GetIndex(v2);
            adjacency[i, j] = v3;
            adjacency[j, i] = v3;
            adjacencyVertices[i].Add(j);
            adjacencyVertices[j].Add(i);
        }
    }
}