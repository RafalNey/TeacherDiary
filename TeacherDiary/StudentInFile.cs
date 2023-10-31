namespace TeacherDiary
{
    public class StudentInFile : StudentBase
    {
        private string fileName;
        public StudentInFile(string name, string surname)
            : base(name, surname)
        {
            fileName = $"{this.Surname.ToLower()}_{this.Name.ToLower()}.txt";
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
            }
            else
            {
                throw new Exception("Dane spoza zakresu walidacji. Tylko od 1 do 6.");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var grade = float.Parse(line);
                        statistics.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }
            }
            return statistics;
        }
    }
}