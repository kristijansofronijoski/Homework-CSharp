/* Make a console application called SumOfEven. Inside it create an array of 6 integers. Get numbers from the input, find and print the sum of the even numbers from the array:

Test Data:
Enter integer no.1:
4
Enter integer no.2:
3
Enter integer no.3:
7
Enter integer no.4:
3
Enter integer no.5:
2
Enter integer no.6:
8
Expected Output:
The result is: 14 */


Console.WriteLine("SumOfEven");
Console.WriteLine("**********");

int[] numbers = new int[6];
int sum = 0;
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine("Enter integer no." + (i + 1) + ":");
    numbers[i] = Convert.ToInt32(Console.ReadLine());
}
foreach (int number in numbers)
{
    if (number % 2 == 0)
    {
        sum += number;
    }
}
Console.WriteLine($"The result is: {sum}");

