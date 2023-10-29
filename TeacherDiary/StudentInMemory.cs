namespace TeacherDiary
{
    public class StudentInMemory : StudentBase
    {
        public StudentInMemory(string name, string surname)
            : base(name, surname) { }

        // Lista ocen studenta.
        private List<float> grades = new List<float>();

        // Dodawanie ocen przy pomocy liczb zmiennoprzecinkowych, np. 3.75
        public override void AddGrade(float grade)
        {
            // Walidacja.
            if (grade >= 1 && grade <= 6)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new Exception("Sorry-Gregory, dane spoza zakresu walidacji. Tylko od 1 do 6.");
            }
        }

        // Wyliczanie oceny koncowej studenta.
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (grades != null)
            {
                foreach (var grade in this.grades)
                {
                    statistics.AddGrade(grade);
                }
                return statistics;
            }
            else
            {
                throw new Exception("Brak ocen.");
            }
        }
    }
}