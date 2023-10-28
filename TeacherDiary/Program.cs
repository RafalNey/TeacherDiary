using System.Globalization;
using System.Security.Principal;
using TeacherDiary;

Console.Clear();
Console.WriteLine("=================================================================");
Console.WriteLine("Witamy w programie wyliczajacym ocene studenta na koniec semestru");
Console.WriteLine("=================================================================");
Console.WriteLine();
Console.WriteLine("Podaj imie studenta:");
string? name = Console.ReadLine();
Console.WriteLine("Podaj nazwisko studenta:");
string? surname = Console.ReadLine();
Console.WriteLine("Podaj plec studenta (M/K):");
string? sex = Console.ReadLine();
Console.WriteLine("Wprowadzanie ocen studenta");
Console.WriteLine("Program akceptuje oceny numeryczne od 1 do 6 z czesciami ulamkowymi np. 3.25 lub z plusami i minusami, np. 4+ lub literowe od A do F.");
Console.WriteLine("Wybierajac litere 'Q' konczysz wprowadzanie ocen.");
Console.WriteLine();

var student = new StudentInMemory(name, surname, sex);

while (true)
{
    Console.WriteLine("Wprowadz kolejna ocene studenta:");
    var input = Console.ReadLine();

    if (input == "q" || input == "Q")
    {
        break;
    }
    try
    {
        student.AddGrade(input);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
    }
    finally
    {

    }
}

var statistics = student.GetStatistics();

if (student.Sex == "K" || student.Sex == "k")
{
    Console.WriteLine($"Studentka {student.Name} {student.Surname}. {statistics.AverageGrade} {statistics.Average}");
}
else
{
    Console.WriteLine($"Student {student.Name} {student.Surname}. {statistics.AverageGrade} {statistics.Average}");
}