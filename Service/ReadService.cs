using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_3.Domain;

namespace Task_3.Service
{
    public class ReadService
    {
        public static (IDictionary<int, Node> Nodes, int Source, int Target) Read(string filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException("File not found");

            var lines = File.ReadLines(filePath).ToArray();
            var sourceNodeNumber = int.Parse(lines[^2]);
            var targetNodeNumber = int.Parse(lines[^1]);

            var nodesLines = lines[1..^2];
            var nodes = new Dictionary<int, Node>();

            var currentNodeNumber = 0;
            foreach (var nodeLine in nodesLines)
            {
                currentNodeNumber += 1;
                if (!nodes.ContainsKey(currentNodeNumber))
                    nodes[currentNodeNumber] = new Node(currentNodeNumber);

                var nodeInfo = nodeLine.Split(' ');
                for (var i = 0; i < nodeInfo.Length; i += 2)
                {
                    if (nodeInfo[i] == "0")
                        break;

                    var currentSourceNodeNumber = int.Parse(nodeInfo[i]);
                    var currentEdgeWeight = int.Parse(nodeInfo[i + 1]);
                    if (!nodes.ContainsKey(currentSourceNodeNumber))
                        nodes[currentSourceNodeNumber] = new Node(currentSourceNodeNumber);

                    nodes[currentSourceNodeNumber].Edges.Add(new Edge()
                        {From = currentSourceNodeNumber, To = currentNodeNumber, Weight = currentEdgeWeight});
                }
            }

            return (nodes, sourceNodeNumber, targetNodeNumber);
        }
    }
}