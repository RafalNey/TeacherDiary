using TeacherDiary;

Console.WriteLine("======================================================");
Console.WriteLine("Witamy w programie wyliczajacym ocene koncowa studenta");
Console.WriteLine("======================================================");
Console.WriteLine("Program akceptuje oceny numeryczne od 1 do 6+ lub literowe od A do F.");
Console.WriteLine("Naciskajac litere 'Q' konczysz wprowadzanie ocen.");
Console.WriteLine();

var student = new Student("Adam", "Kamizelich");

while (true)
{
    Console.WriteLine("Wprowadz kolejna ocene studenta:");
    var input = Console.ReadLine();

    if (input == "q" || input == "Q")
    {
        break;
    }
    student.AddGrade(input);
}

var statistics = student.GetStatistics();
Console.WriteLine($"Student {student.Name} {student.Surname} zasluguje na ocene koncowa: {statistics.Average:N1}");