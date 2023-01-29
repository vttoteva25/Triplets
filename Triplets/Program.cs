using Triplets;

namespace Triplets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var triplets = new List<int[]>();
            for (int i = 0; i < input[1]; i++)
            {
                triplets.Add(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()); 
            }

            var (countOfConflictNodes, numbersOfConflictNodes) = CheckNodeForConflict(input[0], input[1], triplets);
            Console.WriteLine(countOfConflictNodes.ToString());
            Console.WriteLine(string.Join(" ", numbersOfConflictNodes));
          
        }
        private static (int countOfConflictNodes, List<int> numbersOfConflictNodes) CheckNodeForConflict(int vertices, int countTriplets, List<int[]> triplets)
        {
            var countOfConflictNodes = 0;
            var numbersOfConflictEdges = new List<int>();
            int indexOfTripletRemoved = 0;

            while (indexOfTripletRemoved < countTriplets)
            {
                var graph = CreateGraph(vertices, countTriplets, triplets, indexOfTripletRemoved);
               
                    var accessibleVertices = graph.BFS(1);
                    if(accessibleVertices.Count != vertices)
                    {
                        countOfConflictNodes++;
                        numbersOfConflictEdges.Add(indexOfTripletRemoved+1);
                    }
              
                indexOfTripletRemoved++;
            }

            return (countOfConflictNodes, numbersOfConflictEdges);
        }

        private static UndirectedGraph CreateGraph(int vertices, int countTriplets, List<int[]> triplets, int index)
        {
            UndirectedGraph grаph = new UndirectedGraph(vertices);
            
            for (int i = 0; i < countTriplets; i++)
            {
                if (index == i)
                    continue;
                grаph.AddEdge(triplets[i][0], triplets[i][1]);
                grаph.AddEdge(triplets[i][0], triplets[i][2]);
                grаph.AddEdge(triplets[i][1], triplets[i][2]);
            }

            return grаph;
        }
    }

   
}