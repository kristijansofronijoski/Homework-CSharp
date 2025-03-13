/* Make a new console application called StudentGroup
Make 2 arrays called studentsG1 and studentsG2 and fill them with 5 student names.
Get a number from the console between 1 and 2 and print the students from that group in the console.
Ex: studentsG1 ["Zdravko", "Petko", "Stanko", "Branko", "Trajko"]
Test Data:
Enter student group: ( there are 1 and 2 )
1
Expected Output:
The Students in G1 are:
Zdravko
Petko
Stanko
Branko
Trajko */

Console.WriteLine("StudentGroup");
Console.WriteLine("**********");

string[] studentsG1 = { "Zdravko", "Petko", "Stanko", "Branko", "Trajko" };
string[] studentsG2 = { "Joshko", "Mitre", "Zlatko", "Rajko", "Bogoljub" };

Console.WriteLine("Enter student group: ( there are 1 and 2 )");
int group = Convert.ToInt32(Console.ReadLine());

if (group == 1)
{
    Console.WriteLine("The Students in G1 are:");
    foreach (string student in studentsG1)
    {
        Console.WriteLine(student);
    }
}
else if (group == 2)
{
    Console.WriteLine("The Students in G2 are:");
    foreach (string student in studentsG2)
    {
        Console.WriteLine(student);
    }
}
else
{
    Console.WriteLine("Invalid group number");
}

