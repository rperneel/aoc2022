namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split("\n").ToList();
        var total = 0;
        var max = 0;
        for (int i = 0; i < lines.Count; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                if (total > max)
                    max = total;
                total = 0;
            }
            else
            {
                total += int.Parse(lines[i]);
            }
        }

        return new(max.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split("\n").ToList();
        var total = 0;
        var totals = new List<int>();
        for (int i = 0; i < lines.Count; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                totals.Add(total);
                total = 0;
            }
            else
            {
                total += int.Parse(lines[i]);
            }
        }

        return new((totals.OrderByDescending(x => x).Take(3).Sum()).ToString());
    }
}
