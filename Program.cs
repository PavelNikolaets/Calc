
using System.Diagnostics;

char[] operations = [];
int[] nums = [];

string temporary = "";
int index = 0;

string input = Console.ReadLine();

for (int i = 0; i <= input.Length; i++)
{
    if (i != input.Length)
    {
        if (char.IsDigit(input[i]))
        {
            temporary += input[i];
        }
        else
        {
            Array.Resize(ref nums, nums.Length+1);
            Array.Resize(ref operations, operations.Length+1);
            nums[index] = Convert.ToInt32(temporary);
            temporary = "";
            operations[index] = input[i];
            index++;
        }
    }
    else
    {
        Array.Resize(ref nums, nums.Length+1);
        nums[index] = Convert.ToInt32(temporary);
    }
}

Console.WriteLine ($"Числа: {string.Join(",",nums)} \nОператоры: {string.Join(",",operations)}");

int result = 0;
foreach (char item in operations)
{
    switch(item)
    {
        case '+':
            result = nums[0]+nums[1];
            nums[0] = result;
            break;
        
        case '-':
            result = nums[0]-nums[1];
            nums[0] = result;
            break;
        
        default:
            Console.Error.WriteLine("Неизвестный оператор!");
            Process.GetCurrentProcess().Kill();
            break;
    }
    if (nums.Length > 2)
    {
        Array.Copy(nums,2,nums,1,nums.Length-2);
        Array.Resize(ref nums, nums.Length-1);
    }
    else
    {
        Array.Resize(ref nums, nums.Length-1);
    }
}

Console.WriteLine($"{string.Join(',',nums)}");
