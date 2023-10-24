namespace TeacherDiary
{
    public class Student : IStudent
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
                throw new Exception("Dane spoza zakresu walidacji.");
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
                    throw new Exception("To, co wprowadziles nie jest liczba.");
                }
            }
        }
        public void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                case 'a':
                    this.grades.Add(6);
                    break;
                case 'B':
                case 'b':
                    this.grades.Add(5);
                    break;
                case 'C':
                case 'c':
                    this.grades.Add(4);
                    break;
                case 'D':
                case 'd':
                    this.grades.Add(3);
                    break;
                case 'E':
                case 'e':
                    this.grades.Add(2);
                    break;
                case 'F':
                case 'f':
                    this.grades.Add(1);
                    break;
                default:
                    throw new Exception("Niewlasciwa literka.");
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

            // wartosci inicjalne 
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