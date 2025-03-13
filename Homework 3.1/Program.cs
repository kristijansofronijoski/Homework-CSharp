/* Make a method called AgeCalculator
The method will have one input parameter, your birthday date
The method should return your age
Show the age of a user after he inputs a date
Note: take into consideration if the birthday is today, after or before today */

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter your birthday date (dd/mm/yyyy): ");
        bool success = DateTime.TryParse(Console.ReadLine(), out DateTime birthday);
        if (success)
        {
            if (birthday > DateTime.Now)
            {
                Console.WriteLine("You are not born yet :)");
                return;
            }
            else if (birthday.Date == DateTime.Now.Date)
            {
                Console.WriteLine("Happy Birthday!");
            }
            else
            {
                int age = AgeCalculator(birthday);
                Console.WriteLine("You are " + age + " years old");
            }
        }

        else
        {
            Console.WriteLine("Invalid date");
        }
    }
    public static int AgeCalculator(DateTime birthday)
    {
        DateTime currentDateTime = DateTime.Now;
        int age = currentDateTime.Year - birthday.Year;
        if (birthday.Date > currentDateTime.AddYears(-age))
        {
            age--;
        }

        return age;
    }

}
