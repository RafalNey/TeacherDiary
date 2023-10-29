using TeacherDiary;

// Ekran poczatkowy.
Console.Clear();
Console.WriteLine("===================================================================");
Console.WriteLine(" Witamy w programie wyliczajacym ocene studenta na koniec semestru");
Console.WriteLine("===================================================================");
Console.WriteLine();
Console.WriteLine("Wprowadz dane studenta:");
Console.WriteLine();

// Wprowadzanie danych studenta (imie i nazwisko).
string name;
do
{
    Console.WriteLine("Podaj imie studenta:");
    name = Console.ReadLine();
    if (name == null || !name.All(char.IsLetter))
    {
        Console.WriteLine("Imie musi byc jednoczlonowe i zawierac wylacznie litery.");
        Console.WriteLine();
    }
} while (name == null || !name.All(char.IsLetter));

Console.WriteLine();

string surname;
do
{
    Console.WriteLine("Podaj nazwisko studenta:");
    surname = Console.ReadLine();
    if (surname == null || !surname.All(char.IsLetter))
    {
        Console.WriteLine("Nazwisko musi byc jednoczlonowe i zawierac wylacznie litery.");
        Console.WriteLine();
    }
} while (surname == null || !surname.All(char.IsLetter));

// Ekran he he "wyboru".
Console.WriteLine();
Console.WriteLine("Chcesz zapisac oceny studenta do pliku, czy tylko obliczyc jego ocene koncowa?");
Console.WriteLine("Nacisnij:");
Console.WriteLine("'1' aby dopisac oceny studenta do pliku *.txt i wyliczyc jego ocena koncowa.");
Console.WriteLine("'2' Nie zapisujac ocen studenta, jedynie wyliczyc jego ocene koncowa.");
Console.WriteLine();

string choice;
do
{
    choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("Wybrales 1 - z zapisem do pliku");
            AddGradesToFile();
            break;
        case "2":
            Console.WriteLine("Wybrales 2 - bez zapisu do pliku");
            AddGradesToMemory();
            break;
        default:
            Console.WriteLine("Chlopie, tylko 1 albo 2.");
            break;
    }
} while (choice != "1" && choice != "2");

// Wybor 1 - zapis do pliku.
void AddGradesToFile()
{
    var student = new StudentInFile(name, surname);
    EnterGrade(student);
}

// Wybor 2 - tylko w pamieci.
void AddGradesToMemory()
{
    var student = new StudentInMemory(name, surname);
    EnterGrade(student);
}

// Wprowadzanie ocen studenta (wspolne dla obu wyborow).
void EnterGrade(IStudent student)
{
    Console.Clear();
    Console.WriteLine("===================================================================");
    Console.WriteLine($"         Wprowadzasz oceny studenta {name} {surname}");
    Console.WriteLine("===================================================================");
    Console.WriteLine();
    Console.WriteLine("Program akceptuje oceny numeryczne od 1 do 6 z czesciami ulamkowymi np. 3.35");
    Console.WriteLine("lub z plusami i minusami, np. 3+, 3-, -3, lub po amerykansku, litery od A do F.");
    Console.WriteLine("Naciskajac 'Q' konczysz wprowadzanie ocen i wyswietlasz ocene semestralna studenta.");
    Console.WriteLine();
    Console.WriteLine("Wprowadz pierwsza ocene studenta:");

    while (true)
    {
        var input = Console.ReadLine();

        if (input == "q" || input == "Q")
        {
            // Ekran koncowy
            Console.Clear();
            Console.WriteLine("=================================================================");
            Console.WriteLine("      Komputer ostro mysli. Prosimy nie przeszkadzac...");
            Console.WriteLine("=================================================================");
            Console.WriteLine();
            Thread.Sleep(3000);
            break;
        }
        try
        {
            student.AddGrade(input);
            Console.WriteLine("Wprowadz kolejna ocene studenta:");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched: {e.Message}");
        }
        finally
        {
            //A tutaj jeszcze nie mam pomyslu, co dac...
        }
    }

    // Wyswietlenie oceny koncowej studenta.
    var statistics = student.GetStatistics();
    Console.WriteLine($"Student {student.Name} {student.Surname}: {statistics.AverageGrade}");
    Console.WriteLine();
}