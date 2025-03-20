/* Create an ATM application. A customer should be able to authenticate with card number and pin and should be greeted with a message greeting them by full name. 
 * After that they can choose one of the following:

Balance checking - This should print out the current balance of money on their account
Cash withdrawal - This should try and withdraw cash from the users account and print a message. 
                  If it has enough it should print a success message that contains the money withdrawn and the balance of money after the withdrawal
Cash deposition - This should deposit cash on the account and give a message with the new balance of money on the account after the deposit.
In order for the ATM app to work we need Customers. This ATM asks for the number ( string ) of the card and searches through the customers if a card like that exists. 
After that it asks for a pin. If the Pin matches that customer a welcome message is shown and the customer can now choose the options.

Example
Welcome to the ATM app
Please enter your card numer:
> 1234-1234-1234-1234
Enter Pin:
> 4325
Welcome Bob Bobsky!
What would you like to do:
Check Balance
Cash Withdrawal
Cash Deposit
> 2
You withdrew 250$. You have 400$ left on your account.
Thank you for using the ATM app.
Bonus: The balance and pin should not be public

Bonus: The ATM card number to be a number instead of a string. The user should still input 1234-1234-1234-1234.

Bonus: When the Customer finishes with a transaction a question must pop up if the Customer wants to do another action. If not it should print a goodbye message and show up the login menu again.
ate
Bonus: Add an option to register a new card in the system that store the customer in the system if the card number is not used for any other customer */


using System.Runtime.ConstrainedExecution;
using Task_01;

User[] SetUserDataBase()
{
    User[] users = new User[]
    {
        new User(){Username = "Bob Bobsky", CardNumber = "1234-1234-1234-1234"},
        new User(){Username = "Jill Awesome", CardNumber = "4444-1234-1234-4444"},
        new User(){Username = "Greg Gregsky", CardNumber = "0000-1234-0000-1234"}
    };

    users[0].SetPin(1234);
    users[0].SetBalance(100);
    users[1].SetPin(4444);
    users[1].SetBalance(1000);
    users[2].SetPin(0000);
    users[2].SetBalance(10);

    return users;
}

bool IsValidCardNumber (User[] users, string cardNumber)
{
    foreach (var user in users)
    {
        if (user.CardNumber == cardNumber)
        {
            return true;
        }
    }
    return false;
}

bool IsValidPin (User[] users, int pin)
{
    foreach (var user in users)
    {
        if (user.GetPin() == pin)
        {
            return true;
        }
    }
    return false;
}

User[] RegisterNewUser(User[] users)
{
    Console.Write("Enter your full name: ");
    string username = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(username))
    {
        Console.WriteLine("Invalid name. Please try again.");
        return users; 
    }

    Console.Write("Enter a new card number (format: 1234-1234-1234-1234): ");
    string cardNumberInput = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(cardNumberInput))
    {
        Console.WriteLine("Invalid card number. Please try again.");
        return users;
    }

    if (users.Any(user => user.CardNumber == cardNumberInput))
    {
        Console.WriteLine("This card number is already registered.");
        return users;
    }

    Console.Write("Set a PIN (4-digit number): ");
    bool validPin = int.TryParse(Console.ReadLine(), out int pin) && pin >= 1000 && pin <= 9999;
    if (!validPin)
    {
        Console.WriteLine("Invalid PIN. Please try again.");
        return users;
    }

   
    Array.Resize(ref users, users.Length + 1);
    users[users.Length - 1] = new User { Username = username, CardNumber = cardNumberInput };
    users[users.Length - 1].SetPin(pin);
    users[users.Length - 1].SetBalance(0);

    Console.WriteLine("Registration successful!");

    return users;
}


void LogIn(User[] users)
{
    Console.WriteLine("Please enter your card number (format: 1234-1234-1234-1234): ");
    string cardNumber = Console.ReadLine();
    if (!IsValidCardNumber(users, cardNumber))
    {
        Console.WriteLine("Invalid card number.");
        return;
    }

    int counter = 0;
    int numberOfTrys = 3;
    int pin = -1;
    while (counter < numberOfTrys)
    {
        Console.WriteLine("Enter Pin:");
        bool successPin = int.TryParse(Console.ReadLine(), out pin);
        if (!successPin)
        {
            Console.WriteLine("Invalid pin. Please try again.");
            counter++;
        }
        else
        {
            break;
        }
    }
    if (counter == numberOfTrys)
    {
        Console.WriteLine("Too many invalid tries. Please try again later.");
        return;
    }

    bool isValidPin = IsValidPin(users, pin);

    if (isValidPin)
    {
        foreach (var user in users)
        {
            if (user.CardNumber == cardNumber && user.GetPin() == pin)
            {
                Console.WriteLine($"Welcome {user.Username}!");
                Console.WriteLine("What would you like to do:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Cash Withdrawal");
                Console.WriteLine("3. Cash Deposit");
                bool successOption = int.TryParse(Console.ReadLine(), out int option);
                if (!successOption)
                {
                    Console.WriteLine("Invalid option.");
                    return;
                }
                AtmOptionService(user, option);
                Console.WriteLine("Thank you for using the ATM app.");
                Console.WriteLine("Do you want to do another action? (yes/no)");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "yes")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }
            }
        }
    }
}

void AtmOptionService(User user, int option)
{
    int numberOfTrys = 3;
    int withdraw = 0;
    switch (option)
    {
        case 1:
            Console.WriteLine($"Your balance is {user.GetBalance()}$");
            break;
        case 2:
            Console.WriteLine("Enter the amount you want to withdraw:");
            int counter = 0;
            while (counter < numberOfTrys)
            {
                bool successWithdraw = int.TryParse(Console.ReadLine(), out withdraw);
                if (!successWithdraw)
                {
                    Console.WriteLine("Invalid amount. Please try again.");
                    counter++;
                }
            }
            if(counter == numberOfTrys)
            {
                Console.WriteLine("Too many invalid tries. Please try again later.");
                break;
            }

            if (user.GetBalance() >= withdraw)
            {
                user.SetBalance(user.GetBalance() - withdraw);
                Console.WriteLine($"You withdrew {withdraw}$. You have {user.GetBalance()}$ left on your account.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
            break;
        case 3:
            Console.WriteLine("Enter the amount you want to deposit:");
            bool successDeposit = int.TryParse(Console.ReadLine(), out int deposit);
            if (!successDeposit)
            {
                Console.WriteLine("Invalid amount.");
                break;
            }
            user.SetBalance(user.GetBalance() + deposit);
            Console.WriteLine($"You deposited {deposit}$. You have {user.GetBalance()}$ on your account.");
            break;
            default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
    void AtmUserInterface(ref User[] users)
    {
        Console.WriteLine("Welcome to the ATM app");
        Console.WriteLine("For log in press 1, for register press 2");

        bool successOne = int.TryParse(Console.ReadLine(), out int one);
        switch (one)
        {
            case 1:
                LogIn(users);
                break;
            case 2:
                users = RegisterNewUser(users);
                break;
            default:
                AtmUserInterface(ref users);
                break;
        }
    }

User[] users = SetUserDataBase();
while (true)
{
    AtmUserInterface(ref users);
}

