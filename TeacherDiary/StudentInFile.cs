namespace TeacherDiary
{
    public class StudentInFile : StudentBase
    {
        private string fileName;
        public StudentInFile(string name, string surname)
            : base(name, surname)
        {
            // Zdefiniowanie nazwy pliku.
            fileName = $"{this.Surname.ToLower()}_{this.Name.ToLower()}.txt";
        }

        // Lista ocen studenta
        private List<float> grades = new List<float>();

        // Lista dozwolonych liter jako oceny.
        public char[] specialLetters = { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f' };

        // Lista dozwolonych cyfr z plusami i minusami jako ocena.
        public string[] specialGrades = { "+1", "1+", "-2", "2-", "+2", "2+", "-3", "3-", "+3", "3+", "-4", "4-", "+4", "4+", "-5", "5-", "+5", "5+", "-6", "6-" };

        // Zapisywanie ocen do pliku.
        public override void AddGrade(float grade)
        {
            // Walidacja.
            if (grade >= 1 && grade <= 6)
            {
                // Otwarcie pliku, zapisanie oceny i zamkniecie pliku.
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
            }
            else
            {
                throw new Exception("Sorry-Gregory, dane spoza zakresu walidacji. Tylko od 1 do 6.");
            }
        }

        // Zamiana wprowadzanych w rozny sposob ocen na liczby float.
        public override void AddGrade(string grade)
        {
            // Jesli wprowadzam literki A - F.
            if (grade.Length == 1 && specialLetters.Contains(grade[0]))
            {
                switch (grade[0])
                {
                    case 'A':
                    case 'a':
                        this.AddGrade(6.0f);
                        break;
                    case 'B':
                    case 'b':
                        this.AddGrade(5.0f);
                        break;
                    case 'C':
                    case 'c':
                        this.AddGrade(4.0f);
                        break;
                    case 'D':
                    case 'd':
                        this.AddGrade(3.0f);
                        break;
                    case 'E':
                    case 'e':
                        this.AddGrade(2.0f);
                        break;
                    case 'F':
                    case 'f':
                        this.AddGrade(1.0f);
                        break;
                    default:
                        throw new Exception("Nie ma opcji, zebys sie tu znalazl. Cos ty za znak chlopie wprowadzil?");
                }
            }
            // Jesli wprowadzam cyferki od 1 do 6 z plusami i minusami.
            else if (grade.Length == 2 && specialGrades.Contains(grade))
            {
                switch (grade)
                {
                    case "+1":
                    case "1+":
                        this.AddGrade(1.25f);
                        break;
                    case "-2":
                    case "2-":
                        this.AddGrade(1.75f);
                        break;
                    case "+2":
                    case "2+":
                        this.AddGrade(2.25f);
                        break;
                    case "-3":
                    case "3-":
                        this.AddGrade(2.75f);
                        break;
                    case "+3":
                    case "3+":
                        this.AddGrade(3.25f);
                        break;
                    case "-4":
                    case "4-":
                        this.AddGrade(3.75f);
                        break;
                    case "+4":
                    case "4+":
                        this.AddGrade(4.25f);
                        break;
                    case "-5":
                    case "5-":
                        this.AddGrade(4.75f);
                        break;
                    case "+5":
                    case "5+":
                        this.AddGrade(5.25f);
                        break;
                    case "-6":
                    case "6-":
                        this.AddGrade(5.75f);
                        break;
                    default:
                        throw new Exception("To niemozliwe! Nie ma opcji, zebys sie tu znalazl. Cos ty za znak chlopie wprowadzil?");
                }
            }
            // Jesli wprowadzone dane da sie sparsowac => przechodzimy na liczby float.
            else if (float.TryParse(grade, out float result))
            {
                result = float.Parse(grade);
                this.AddGrade(result);
            }
            // A jesli juz zupelnie nic nie da sie z tym zrobic...
            else
            {
                throw new Exception("Wprowadziles niewlasciwy ciag znakow.");
            }
        }

        // Wyliczenie oceny koncowej studenta.
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            // Sprawdzanie, czy taki plik juz istnieje.
            if (File.Exists(fileName))
            {
                // Otwarcie pliku i na koniec zamkniecie go.
                using (var reader = File.OpenText($"{fileName}"))
                {
                    // Odczytanie danych z pliku, linijka po linijce.
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        // Wprowadzenie tych danych do wyliczenia oceny koncowej.
                        var grade = float.Parse(line);
                        statistics.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }
            }
            // Jesli dany plik nie istnieje, to uzyte zostana wartosci inicjalne.
            return statistics;
        }
    }
}