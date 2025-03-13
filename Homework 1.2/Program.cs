/* Create new console application called “AverageNumber” that takes four numbers as input to calculate and print the average.

Test Data:
Enter the First number: 10
Enter the Second number: 15
Enter the third number: 20
Enter the four number: 30
Expected Output:
The average of 10, 15, 20 and 30 is: 18
*/

Console.WriteLine("Average Number");
Console.WriteLine("**************");

double avg = 4;
double result = 0;
Console.WriteLine("Pleas enter 1-4 number: ");
bool firstSuccess = double.TryParse(Console.ReadLine(), out double firstNumber);

Console.WriteLine("Pleas enter 2-4 number: ");
bool secondSuccess = double.TryParse(Console.ReadLine(), out double secondNumber);

Console.WriteLine("Pleas enter 3-4 number: ");
bool thirdSuccess = double.TryParse(Console.ReadLine(), out double thirdNumber);

Console.WriteLine("Pleas enter 4-4 number: ");
bool forthSuccess = double.TryParse(Console.ReadLine(), out double fourthNumber);

result = (firstNumber + secondNumber + thirdNumber + fourthNumber) / avg;

Console.WriteLine($"The average of {firstNumber}, {secondNumber}, {thirdNumber} and {forthSuccess} is: " + result);
