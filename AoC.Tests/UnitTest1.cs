using System.Collections.Generic;
using AdventOfCode;
using NUnit.Framework;

namespace AoC.Tests
{
    public class Tests
    {
        // losses
        [TestCase(AdventOfCode.Throws.Rock, AdventOfCode.Throws.Scissors, 3)]
        [TestCase(AdventOfCode.Throws.Paper, AdventOfCode.Throws.Rock, 1)]
        [TestCase(AdventOfCode.Throws.Scissors, AdventOfCode.Throws.Paper, 2)]
        // ties
        [TestCase(AdventOfCode.Throws.Rock, AdventOfCode.Throws.Rock, 4)]
        [TestCase(AdventOfCode.Throws.Paper, AdventOfCode.Throws.Paper, 5)]
        [TestCase(AdventOfCode.Throws.Scissors, AdventOfCode.Throws.Scissors, 6)]
        // wins
        [TestCase(AdventOfCode.Throws.Rock, AdventOfCode.Throws.Paper, 8)]
        [TestCase(AdventOfCode.Throws.Paper, AdventOfCode.Throws.Scissors, 9)]
        [TestCase(AdventOfCode.Throws.Scissors, AdventOfCode.Throws.Rock, 7)]
        public void Day2_Part1_CalculateScore(AdventOfCode.Throws opponent, AdventOfCode.Throws me, int outcome)
        {
            var subject = new Day02();

            var result = Day02.WhoWon(opponent, me);
            Assert.AreEqual(outcome, result);
        }

        // losses
        [TestCase(AdventOfCode.Throws.Rock, Outcomes.Loss, AdventOfCode.Throws.Scissors)]
        [TestCase(AdventOfCode.Throws.Paper, Outcomes.Loss, AdventOfCode.Throws.Rock)]
        [TestCase(AdventOfCode.Throws.Scissors, Outcomes.Loss, AdventOfCode.Throws.Paper)]
        // ties
        [TestCase(AdventOfCode.Throws.Rock, Outcomes.Tie, AdventOfCode.Throws.Rock)]
        [TestCase(AdventOfCode.Throws.Paper, Outcomes.Tie, AdventOfCode.Throws.Paper)]
        [TestCase(AdventOfCode.Throws.Scissors, Outcomes.Tie, AdventOfCode.Throws.Scissors)]
        // wins
        [TestCase(AdventOfCode.Throws.Rock, Outcomes.Win, AdventOfCode.Throws.Paper)]
        [TestCase(AdventOfCode.Throws.Paper, Outcomes.Win, AdventOfCode.Throws.Scissors)]
        [TestCase(AdventOfCode.Throws.Scissors, Outcomes.Win, AdventOfCode.Throws.Rock)]
        public void Day2_Part2_WhatDoIThrow(AdventOfCode.Throws opponent, Outcomes desired, AdventOfCode.Throws needToThrow)
        {
            var subject = new Day02();

            var result = Day02.WhatDoIThrow(opponent, desired);
            Assert.AreEqual(needToThrow, result);
        }

        [TestCase("2-4,6-8", false)]
        [TestCase("2-3,4-5", false)]
        [TestCase("5-7,7-9", false)]
        [TestCase("2-8,3-7", true)]
        [TestCase("6-6,4-6", true)]
        [TestCase("2-6,4-8", false)]
        public void Day4_Part1_ContainsRange(string input, bool outcome)
        {
            var splits = input.Split(',');
            var r1 = new Range(splits[0]);
            var r2 = new Range(splits[1]);

            var result = r1.ContainsRange(r2);
            var result2 = r2.ContainsRange(r1);

            Assert.AreEqual(outcome, result || result2);
        }

        [TestCase("2-4,6-8", false)]
        [TestCase("2-3,4-5", false)]
        [TestCase("5-7,7-9", true)]
        [TestCase("2-8,3-7", true)]
        [TestCase("6-6,4-6", true)]
        [TestCase("2-6,4-8", true)]
        public void Day4_Part1_Overlaps(string input, bool outcome)
        {
            var splits = input.Split(',');
            var r1 = new Range(splits[0]);
            var r2 = new Range(splits[1]);

            var result = r1.Overlaps(r2);
            var result2 = r2.Overlaps(r1);

            Assert.AreEqual(outcome, result || result2);
        }
    }
}