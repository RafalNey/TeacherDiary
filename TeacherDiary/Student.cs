namespace TeacherDiary
{
    public class Student
    {
        private List<float> grades = new List<float>();
        public Student(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 6.5)
            {
                this.grades.Add(grade);
            }
            else
            {
                Console.Write("Invalid data.");
            }
        }
        public void AddGrade(string? grade)
        {
            if (grades != null)
            {
                if (float.TryParse(grade, out float value))
                {
                    this.AddGrade(value);
                }
                else
                {
                    Console.Write("This string is not a float. Impossible to parse.");
                }
            }
        }
        public void AddGrade(int grade)
        {
            float value = (float)grade;
            this.AddGrade(value);
        }
        public void AddGrade(double grade)
        {
            float value = (float)grade;
            this.AddGrade(value);
        }
        public void AddGrade(long grade)
        {
            float value = (float)grade;
            this.AddGrade(value);
        }
        public void AddGrade(ulong grade)
        {
            float value = (float)grade;
            this.AddGrade(value);
        }
        public Statistics GetStatistics()
        {
            var statistics = new Statistics();

            // inicjalne wartosci
            statistics.Average = 0;
            statistics.Min = float.MaxValue;
            statistics.Max = float.MinValue;
            statistics.Sum = this.grades.Count;

            foreach (var grade in grades)
            {
                statistics.Max = Math.Max(statistics.Max, grade);
                statistics.Min = Math.Min(statistics.Min, grade);
                statistics.Average += grade;
            }
            if (statistics.Sum != 0)
            {
                statistics.Average /= statistics.Sum;
            }

            return statistics;
        }
    }
}