using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Triplets
{
    internal class UndirectedGraph
    {
        private int vertices;
        private int edges = 0;
        private List<int>[] adjacencyLists;

        public UndirectedGraph(int vertices)
        {
            this.vertices = vertices;

            this.adjacencyLists = new List<int>[vertices + 1];
            for (int i = 1; i < this.adjacencyLists.Length; i++)
                this.adjacencyLists[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {          
            if ((v > this.adjacencyLists.Length) || (w > this.adjacencyLists.Length))
                throw new ArgumentException("Invalid node number specified.");

            if (!this.adjacencyLists[v].Contains(w))
            {
                this.adjacencyLists[v].Add(w);
                this.adjacencyLists[w].Add(v);

                this.edges++;
            }

        }

        public List<int> BFS(int vertice)
        {
            var result = new List<int>();
            bool[] visited = new bool[vertices+1];
            for (int i = 0; i < vertices; i++)
                visited[i] = false;

            LinkedList<int> queue = new LinkedList<int>();

            visited[vertice] = true;
            queue.AddLast(vertice);

            while (queue.Any())
            {
                vertice = queue.First();
                result.Add(vertice);
                queue.RemoveFirst();
              
                List<int> list = adjacencyLists[vertice];

                foreach (var value in list)
                {
                    if (!visited[value])
                    {
                        visited[value] = true;
                        queue.AddLast(value);
                    }
                }
            }
            return result;
        }       
    }
}

