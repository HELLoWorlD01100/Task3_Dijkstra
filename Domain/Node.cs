using System.Collections.Generic;

namespace Task_3.Domain
{
    public class Node
    {
        public int Number { get; set; }
        public int Weight { get; set; } = int.MaxValue;
        public ISet<Edge> Edges { get; set; } = new HashSet<Edge>();
        public bool Marked = false;

        public Node(int number)
        {
            Number = number;
        }
    }
}