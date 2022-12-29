using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day03 : BaseDay
    {
        private string _input;
        private List<string> lines;
        private List<char> charValues = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();

        public Day03()
        {
            _input = File.ReadAllText(InputFilePath);
            lines = _input.Split("\n").ToList();
        }

        private int GetCharCode(char c)
        {
            return charValues.IndexOf(c) + 1;
        }

        public override ValueTask<string> Solve_1()
        {
            var sum = 0;

            foreach (var line in lines)
            {
                string left = "";
                string right = "";
                var length = line.Length;
                left = line.Substring(0, length / 2);
                right = line.Substring(length / 2, length / 2);

                var duplicates = GetItemsInBoth(left,right);
                foreach (var dup in duplicates)
                {
                    sum += GetCharCode(dup);
                }
            }

            return new(sum.ToString());
        }

        private List<char> GetItemsInBoth(string left, string right)
        {
            List<char> list = new List<char>(); 
            foreach (var leftItem in left)
            {
                if (right.Contains(leftItem))
                {
                    if(!list.Contains(leftItem))
                        list.Add(leftItem);
                }
            }
            return list;
        }

        public override ValueTask<string> Solve_2()
        {
            var sum = 0;

            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    continue;
                }
                // need 3 lines
                var l1 = lines[i];
                var l2 = lines[++i];
                var l3 = lines[++i];

                var l1l2Common = GetItemsInBoth(l1, l2);
                var l2l3Common = GetItemsInBoth(l2, l3);
                var l1l3Common = GetItemsInBoth(l1, l3);

                var m1 = l1l2Common.Where(x => l2l3Common.Contains(x));
                var m2 = l2l3Common.Where(x => l1l3Common.Contains(x));

                var m3 = m1.Where(x => m2.Contains(x));

                foreach (var item in m3)
                {
                    sum += GetCharCode(item);
                }
            }

            return new(sum.ToString());
        }
    }
}
