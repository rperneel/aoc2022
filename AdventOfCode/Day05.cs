using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day05 : BaseDay
    {
        private string _input;
        private List<string> lines;

        private Dictionary<int, Stack<string>> cargoMap = new Dictionary<int, Stack<string>>();

        public Day05()
        {
            _input = File.ReadAllText(InputFilePath);
            lines = _input.Split("\n").ToList();
        }

        public override ValueTask<string> Solve_1()
        {
            // build the initial cargo map
            InitCargoMap();

            for (int i = 10; i < lines.Count; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    continue;
                }
                var inputs = lines[i].Split(" ");
                var count = int.Parse(inputs[1]);
                var from = int.Parse(inputs[3]);
                var to = int.Parse(inputs[5]);

                for (int j = 0; j < count; j++)
                {
                    var popped = cargoMap[from].Pop();
                    cargoMap[to].Push(popped);
                }
            }

            return new(string.Join("", cargoMap.Select(kv => kv.Value.Peek())));
        }

        /// <summary>
        /// Sepcific to my day 5 input
        /// </summary>
        private void InitCargoMap()
        {
            cargoMap.Clear();
            cargoMap.Add(1, new Stack<string>(new List<string>() { "D", "H", "N", "Q", "T", "W", "V", "B" }));
            cargoMap.Add(2, new Stack<string>(new List<string>() { "D", "W", "B" }));
            cargoMap.Add(3, new Stack<string>(new List<string>() { "T", "S", "Q", "W", "J", "C" }));
            cargoMap.Add(4, new Stack<string>(new List<string>() { "F", "J", "R", "N", "Z", "T", "P" }));
            cargoMap.Add(5, new Stack<string>(new List<string>() { "G", "P", "V", "J", "M", "S", "T" }));
            cargoMap.Add(6, new Stack<string>(new List<string>() { "B", "W", "F", "T", "N" }));
            cargoMap.Add(7, new Stack<string>(new List<string>() { "B", "L", "D", "Q", "F", "H", "V", "N" }));
            cargoMap.Add(8, new Stack<string>(new List<string>() { "H", "P", "F", "R" }));
            cargoMap.Add(9, new Stack<string>(new List<string>() { "Z", "S", "M", "B", "L", "N", "P", "H" }));
        }

        public override ValueTask<string> Solve_2()
        {
            // build the initial cargo map
            InitCargoMap();

            for (int i = 10; i < lines.Count; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    continue;
                }
                var inputs = lines[i].Split(" ");
                var count = int.Parse(inputs[1]);
                var from = int.Parse(inputs[3]);
                var to = int.Parse(inputs[5]);

                var pops = new Stack<string>();

                for (int j = 0; j < count; j++)
                {
                    pops.Push(cargoMap[from].Pop());
                }
                foreach (var pop in pops)
                {
                    cargoMap[to].Push(pop);
                }
                
            }

            return new(string.Join("", cargoMap.Select(kv => kv.Value.Peek())));
        }
    }
}
