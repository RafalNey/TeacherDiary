using System.Globalization;
namespace TeacherDiary
{
    public class StudentInFile : StudentBase
    {
        private const string fileName = "grades.txt";
        private List<float> grades = new List<float>();
        public StudentInFile(string name, string surname, string sex)
            : base(name, surname, sex)
        {
        }
        public override void AddGrade(float grade)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(grade);
            }


            if (grade >= 0 && grade <= 6.5)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new Exception("Dane spoza zakresu walidacji.");
            }
        }
        public override void AddGrade(string? grade)
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
        public override void AddGrade(char grade)
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
        public override void AddGrade(int grade)
        {
            float value = (float)grade;
            this.AddGrade(value);
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Sum = this.grades.Count;

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
                throw new Exception("Semestr nie zaliczony! Brak ocen. Do poprawki.");
            }

        }
    }
}

// wartosci inicjalne 
/*            statistics.Average = 0;
            statistics.Sum = this.grades.Count;

            foreach (var grade in grades)
            {
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
*/