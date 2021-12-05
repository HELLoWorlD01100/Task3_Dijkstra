using System.Collections.Generic;
using System.Linq;
using Task_3.Domain;

namespace Task_3.Service
{
    public class AlgoRunner
    {
        public (bool Result, Dictionary<int, int> Path) Run(IDictionary<int, Node> nodes, int source, int target)
        {
            var result = false;
            var currentNode = nodes[source];
            currentNode.Weight = 0;
            var visitedNodesCount = 0;
            var parentArray = new Dictionary<int, int>();
            while (visitedNodesCount < nodes.Count && currentNode.Weight != int.MaxValue)
            {
                currentNode.Marked = true;
                visitedNodesCount += 1;
                
                if (currentNode.Number == target)
                    result = true;

                foreach (var edge in currentNode.Edges)
                {
                    var currentTargetNode = nodes[edge.To];
                    if (currentNode.Weight + edge.Weight < currentTargetNode.Weight)
                    {
                        currentTargetNode.Weight = currentNode.Weight + edge.Weight;
                        parentArray[currentTargetNode.Number] = currentNode.Number;
                    }
                }
                if (visitedNodesCount < nodes.Count)
                    currentNode = nodes.Values.Where(x => x.Marked == false)
                        .Aggregate((x, y) => x.Weight < y.Weight ? x : y);
            } 

            return (result, parentArray);
        }
    }
}