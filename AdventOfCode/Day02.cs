using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public enum Throws
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public enum Outcomes
    {
        Win = 6,
        Tie = 3,
        Loss = 0
    }

    public class Day02 : BaseDay
    {
        private string _input;
        private List<string> lines;

        public Day02()
        {
            _input = File.ReadAllText(InputFilePath);
            lines = _input.Split("\n").ToList();
        }
        public override ValueTask<string> Solve_1()
        {
            var score = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var combo = line.Split(" ");
                score += WhoWon(GetThrow(combo[0]), GetThrow(combo[1]));
            }

            return new(score.ToString());
        }

        public Throws GetThrow(string v)
        {
            return v switch
            {
                "A" or "X" => Throws.Rock,
                "B" or "Y" => Throws.Paper,
                "C" or "Z" => Throws.Scissors,
                _ => throw new Exception("Unknown Throw"),
            };
        }

        public Outcomes GetDesiredOutcome(string v)
        {
            return v switch
            {
                "X" => Outcomes.Loss,
                "Y" => Outcomes.Tie,
                "Z" => Outcomes.Win,
                _ => throw new Exception("Unknown Outcome"),
            };
        }

        public static int WhoWon(Throws opponent, Throws me)
        {
            if (opponent == Throws.Rock)
            {
                if (me == Throws.Rock)
                {
                    return (int)Outcomes.Tie + (int)me;
                }
                else if (me == Throws.Paper)
                {
                    return (int)Outcomes.Win + (int)me;
                }
                else if (me == Throws.Scissors)
                {
                    return (int)Outcomes.Loss + (int)me;
                }
                throw new Exception("Unknown Combination");
            }
            else if (opponent == Throws.Paper)
            {
                if (me == Throws.Rock)
                {
                    return (int)Outcomes.Loss + (int)me;
                }
                else if (me == Throws.Paper)
                {
                    return (int)Outcomes.Tie + (int)me;
                }
                else if (me == Throws.Scissors)
                {
                    return (int)Outcomes.Win + (int)me;
                }
                throw new Exception("Unknown Combination");
            } 
            else
            {
                if (me == Throws.Rock)
                {
                    return (int)Outcomes.Win + (int)me;
                }
                else if (me == Throws.Paper)
                {
                    return (int)Outcomes.Loss + (int)me;
                }
                else if (me == Throws.Scissors)
                {
                    return (int)Outcomes.Tie + (int)me;
                }
                throw new Exception("Unknown Combination");
            }

        }

        public override ValueTask<string> Solve_2()
        {
            var score = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var combo = line.Split(" ");

                var opponent = GetThrow(combo[0]);
                var desiredOutcome = GetDesiredOutcome(combo[1]);
                var myThrow = WhatDoIThrow(opponent, desiredOutcome);
                score += WhoWon(GetThrow(combo[0]), myThrow);
            }

            return new(score.ToString());
        }

        public static Throws WhatDoIThrow(Throws opponent, Outcomes desiredOutcome)
        {
            if (desiredOutcome == Outcomes.Loss)
            {
                if (opponent == Throws.Rock)
                {
                    return Throws.Scissors;
                }
                else if (opponent == Throws.Paper)
                {
                    return Throws.Rock;
                }
                else
                {
                    return Throws.Paper;
                }
            }
            else if (desiredOutcome == Outcomes.Tie)
            {
                if (opponent == Throws.Rock)
                {
                    return Throws.Rock;
                }
                else if (opponent == Throws.Paper)
                {
                    return Throws.Paper;
                }
                else
                {
                    return Throws.Scissors;
                }
            }
            else
            {
                if (opponent == Throws.Rock)
                {
                    return Throws.Paper;
                }
                else if (opponent == Throws.Paper)
                {
                    return Throws.Scissors;
                }
                else
                {
                    return Throws.Rock;
                }
            }
        }
    }
}
