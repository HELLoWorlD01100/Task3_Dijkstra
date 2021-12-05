using System.Collections.Generic;
using System.IO;
using System.Text;
using Task_3.Service;

namespace Task_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var (nodes, source, target) = ReadService.Read(Constants.InputFile);
            var (result, parentArray) = new AlgoRunner().Run(nodes, source, target);

            var sb = new StringBuilder();
            if (result == false)
            {
                sb.AppendLine("N");
            }
            else
            {
                sb.AppendLine("Y");
                var path = new List<int>();
                var currentNodeNumber = target;
                path.Add(currentNodeNumber);
                while (parentArray.ContainsKey(currentNodeNumber))
                {
                    path.Add(parentArray[currentNodeNumber]);
                    currentNodeNumber = parentArray[currentNodeNumber];
                }

                path.Reverse();
                sb.AppendLine(string.Join(' ', path));
                sb.Append(nodes[target].Weight);
            }

            File.WriteAllText(Constants.OutputFile, sb.ToString());
        }
    }
}