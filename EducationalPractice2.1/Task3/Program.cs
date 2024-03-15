using System;

class Task3
{
    static bool ContainsDuplicate(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    static void Main()
    {
        Console.WriteLine("Input length of array");
        int lengthOfArray = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Input array of numbers:");
        int[] nums = new int[lengthOfArray];

        for (int i = 0; i < lengthOfArray; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        bool hasDuplicate = ContainsDuplicate(nums);
        Console.WriteLine("Is array have duplicates?");
        Console.WriteLine(hasDuplicate ? "True" : "False");
    }
}

