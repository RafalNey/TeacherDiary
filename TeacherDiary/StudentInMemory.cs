namespace TeacherDiary
{
    public class StudentInMemory : StudentBase
    {
        public StudentInMemory(string name, string surname)
            : base(name, surname) { }

        private List<float> grades = new List<float>();

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new Exception("Dane spoza zakresu walidacji. Tylko od 1 do 6.");
            }
        }

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