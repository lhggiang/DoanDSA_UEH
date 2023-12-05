using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class NodePriorityQueue
    {
        public double distance { get; set; }
        public int verticesIndex { get; set; }
        public NodePriorityQueue next { get; set; }
        public NodePriorityQueue(double distance, int verticesIndex)
        {
            this.distance = distance;
            this.verticesIndex = verticesIndex;
            next = null;
        }
    }
    public class PriorityQueueForGraph
    {
        private NodePriorityQueue front;
        public PriorityQueueForGraph()
        {
            front = null;
        }
        public void Enqueue(double distance, int verticesIndex)
        {
            NodePriorityQueue newNode = new NodePriorityQueue(distance, verticesIndex);

            // Nếu hàng đợi trống hoặc đỉnh có độ ưu tiên cao hơn đỉnh đầu tiên
            if (front == null || distance < front.distance)
            {
                newNode.next = front;
                front = newNode;
            }
            else
            {
                NodePriorityQueue current = front;

                // Tìm đỉnh có độ ưu tiên cao hơn để chèn sau đó
                while (current.next != null && distance >= current.next.distance)
                {
                    current = current.next;
                }

                newNode.next = current.next;
                current.next = newNode;
            }
        }
        public bool IsEmpty()
        {
            if (front == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetVerticesIndexFront()
        {
            int index = front.verticesIndex; return index;
        }
        public double GetDistanceFront()
        {
            double dis = front.distance; return dis;
        }
        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            front = front.next;
        }
        public void PrintQueue()
        {
            NodePriorityQueue current = front;
            Console.WriteLine("Xong");
            while (current != null)
            {
                Console.WriteLine($"Value: {current.distance}, Priority: {current.verticesIndex}");
                current = current.next;
            }
        }
    }
}
