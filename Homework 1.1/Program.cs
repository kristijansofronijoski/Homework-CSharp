/*
 Create new console application called“RealCalculator” that takes two numbers from the input and asks what operation would the user want to be done ( +, - , * , / ). Then it returns the result.

Test Data:
Enter the First number: 10
Enter the Second number: 15
Enter the Operation: +
Expected Output:
The result is: 25
*/

Console.WriteLine("Real Calculator");
Console.WriteLine("Enter The first number: ");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter The second number: ");
double num2 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter the Operator: ");
char operation = Convert.ToChar(Console.ReadLine());

double result = 0;
bool validOperation = true;

switch (operation)
{
    case '+':
        result = num1 + num2;
        break;
    case '-':
        result = num1 - num2;
        break;
    case '*':
        result = num1 * num2;
        break;
    case '/':
        if (num2 != 0)
            result = num1 / num2;
        else
        {
            Console.WriteLine("Division by zero is not allowed");
            validOperation = false;
        }
        break;
}
if (validOperation)
{
    Console.WriteLine("The result is: " + result);
}
