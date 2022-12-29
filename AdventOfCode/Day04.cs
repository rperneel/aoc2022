using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Range
    {
        public Range(string input)
        {
            var splits = input.Split('-');
            Start = int.Parse(splits[0]);
            Finish = int.Parse(splits[1]);
        }
        public int Start { get; set; }
        public int Finish { get; set; }

        public bool ContainsRange(Range other)
        {
            // are my starting and ending containing the other start/end
            if (this.Start <= other.Start && this.Finish >= other.Finish)
            {
                return true;
            }
            if (other.Start <= this.Start && other.Finish >= this.Finish)
            {
                return true;
            }
            return false;
        }

        public bool Overlaps(Range other)
        {
            return this.Start <= other.Finish && other.Start <= this.Finish;
        }
    }

    public class Day04 : BaseDay
    {
        private string _input;
        private List<string> lines;

        public Day04()
        {
            _input = File.ReadAllText(InputFilePath);
            lines = _input.Split("\n").ToList();
        }

        public override ValueTask<string> Solve_1()
        {
            var sum = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                var splits = line.Split(',');
                var first = new Range(splits[0]);
                var second = new Range(splits[1]);

                if (first.ContainsRange(second))
                {
                    sum++;
                } 
                else if (second.ContainsRange(first))
                {
                    sum++;
                }

            }

            return new(sum.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var sum = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                var splits = line.Split(',');
                var first = new Range(splits[0]);
                var second = new Range(splits[1]);

                if (first.Overlaps(second))
                {
                    sum++;
                }
                else if (second.Overlaps(first))
                {
                    sum++;
                }

            }

            return new(sum.ToString());
        }

    }
}
