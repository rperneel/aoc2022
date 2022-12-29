using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day06 : BaseDay
    {
        private string _input;

        public Day06()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
            var count = 0;

            var characters = "";

            for (int i = 0; i < _input.Length; i++)
            {
                var c = _input[i];

                if (characters.Length < 3)
                {
                    characters += c;
                }
                else
                {
                    characters += c;
                    if (characters.Length > 4)
                    {
                        characters = characters.Substring(characters.Length - 4, 4);   
                    }
                    var distinct = characters.Distinct();
                    if (distinct.Count() == 4)
                    {
                        count = i + 1;
                        break;
                    }
                }
            }

            return new(count.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var count = 0;

            var characters = "";

            for (int i = 0; i < _input.Length; i++)
            {
                var c = _input[i];

                if (characters.Length < 13)
                {
                    characters += c;
                }
                else
                {
                    characters += c;
                    if (characters.Length > 14)
                    {
                        characters = characters.Substring(characters.Length - 14, 14);
                    }
                    var distinct = characters.Distinct();
                    if (distinct.Count() == 14)
                    {
                        count = i + 1;
                        break;
                    }
                }
            }

            return new(count.ToString());
        }
    }
}
