
static bool IsOperator(char symbol)
{
    List<char> operators = ['-','+','*','/'];
    return operators.Contains(symbol) ? true : false;
}

static string multiplication(string num1, string num2)
{
    return Convert.ToString(Convert.ToDouble(num1) * Convert.ToDouble(num2));
}

static string division(string num1, string num2)
{
    return Convert.ToString(Convert.ToDouble(num1) / Convert.ToDouble(num2));
}

static string addition(string num1, string num2)
{
    return Convert.ToString(Convert.ToDouble(num1) + Convert.ToDouble(num2));
}

static string subtraction(string num1, string num2)
{
    return Convert.ToString(Convert.ToDouble(num1) - Convert.ToDouble(num2));
}

{
    while (true)
    {
        List<string> line = new();
        string temporary = "";

        string input = Console.ReadLine();

        if (input == "exit")
        {
            break;
        }

        for (int i = 0; i <= input.Length; i++)
        {
            if (i != input.Length)
            {
                if (char.IsDigit(input[i]))
                {
                    temporary += input[i];
                }
                else if (IsOperator(input[i]))
                {
                    line.Add(Convert.ToString(temporary));
                    line.Add(Convert.ToString(input[i]));
                    temporary = "";
                }
            }
            else 
            {
                line.Add(temporary);
            }
        }
        Console.WriteLine(string.Join(",", line));
        while (line.Count != 1)
        {    
            if (line.Contains("*"))
            {
                int index = line.FindIndex(x => x == "*");
                line[index-1] = multiplication(line[index-1], line[index+1]);
                line.RemoveRange(index, 2);
            }
            else if (line.Contains("/"))
            {
                int index = line.FindIndex(x => x == "/");
                line[index-1] = division(line[index-1], line[index+1]);
                line.RemoveRange(index, 2);
            }
            else if (line.Contains("+"))
            {
                int index = line.FindIndex(x => x == "+");
                line[index-1] = addition(line[index-1], line[index+1]);
                line.RemoveRange(index, 2);
            }
            else if (line.Contains("-"))
            {
                int index = line.FindIndex(x => x == "-");
                line[index-1] = subtraction(line[index-1], line[index+1]);
                line.RemoveRange(index, 2);
            }   
        }
        Console.WriteLine($"Результат: {string.Join(", ", line)}");
    }
}