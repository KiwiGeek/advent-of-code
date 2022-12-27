﻿namespace TwentyFifteen;

public class AdventOfCode
{
    static uint _startAt = 16;

    static void Main(string[] args)
    {

        // Try to interpret any incoming parameters at a skip command,
        // overriding the startAt set above.
        if (args.Any()) {
            uint.TryParse(args[0], out _startAt);
        }

        foreach (Type d in new List<Type>() { typeof(Day01), typeof(Day02), typeof(Day03), typeof(Day04),
                                              typeof(Day05), typeof(Day06), typeof(Day07), typeof(Day08),
                                              typeof(Day09), typeof(Day10), typeof(Day11), typeof(Day12),
                                              typeof(Day13), typeof(Day14), typeof(Day15), typeof(Day16)})
        {
            ProcessDay(d);
        }

    }

    internal static void ProcessDay(Type dayType) 
    {
        // Arrange
        if (!dayType.GetInterfaces().Contains(typeof(IDay))) throw new InvalidOperationException();
        IDay? day = (IDay?)Activator.CreateInstance(dayType)!;
        if (day == null) throw new InvalidOperationException();
        if (_startAt > day.Index) return;

        // Act
        day.Process($"./Assets/day{day.Index:00}.txt");

        // Assert (lolz)
        Console.WriteLine($"Day {day.Index}");
        Console.WriteLine($"  Part 1 - {day.PartOneDescription}: {day.PartOne}");
        Console.WriteLine($"  Part 2 - {day.PartTwoDescription}: {day.PartTwo}");
    }
}