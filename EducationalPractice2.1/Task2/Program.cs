using System;
using System.Collections.Generic;

class Task2
{
    static void Main()
    {
        int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };
        int target = 8;

        List<List<int>> result = CombinationSum(candidates, target);

        foreach (List<int> combination in result)
        {
            for (int i = 0; i < combination.Count; i++)
            {
                Console.Write(combination[i]);
                if (i < combination.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }

    static List<List<int>> CombinationSum(int[] candidates, int target)
    {
        List<List<int>> result = new List<List<int>>();

        List<int> combination = new List<int>();

        Backtrack(candidates, target, 0, combination, result);

        return result;
    }

    static void Backtrack(int[] candidates, int target, int start, List<int> combination, List<List<int>> result)
    {
        if (target == 0)
        {
            result.Add(new List<int>(combination));
            return;
        }

        if (target < 0)
        {
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            combination.Add(candidates[i]);
            Backtrack(candidates, target - candidates[i], i + 1, combination, result);
            combination.RemoveAt(combination.Count - 1);
        }
    }
}
