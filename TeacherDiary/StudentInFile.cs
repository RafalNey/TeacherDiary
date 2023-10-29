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

        // Wyliczenie oceny koncowej studenta.
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            // Sprawdzanie, czy plik z ocenami juz istnieje.
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
            // A jesli dany plik nie istnieje, to uzyte zostana wartosci inicjalne.
            return statistics;
        }
    }
}