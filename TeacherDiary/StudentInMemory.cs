namespace TeacherDiary
{
    public class StudentInMemory : StudentBase
    {
        // Klasa Student w pamieci (imie, nazwisko, plec)
        public StudentInMemory(string name, string surname, string sex)
            : base(name, surname, sex) { }

        // Lista ocen studenta
        private List<float> grades = new List<float>();

        // Lista dozwolonych liter jako oceny
        public char[] specialLetters = { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f' };

        // Lista dozwolonych cyfr z plusami i minusami jako ocena
        public string[] specialGrades = { "1", "+1", "1+", "2", "-2", "2-", "+2", "2+", "3", "-3", "3-", "+3", "3+", "4", "-4", "4-", "+4", "4+", "5", "-5", "5-", "+5", "5+", "6", "-6", "6-" };

        // Dodawanie ocen studentowi (string)     
        public override void AddGrade(string grade)
        {
            if (grade.Length == 1 && specialLetters.Contains(grade[0]))
            {
                char result = char.Parse(grade);
                this.AddGrade(result);
            }

            // Dodawanie ocen przy pomocy cyferek od 1 do 6 z plusami i minusami.
            else if (specialGrades.Contains(grade))
            {
                switch (grade)
                {
                    case "1":
                        this.AddGrade(1);
                        break;
                    case "+1":
                    case "1+":
                        this.AddGrade(1.25f);
                        break;
                    case "-2":
                    case "2-":
                        this.AddGrade(1.75f);
                        break;
                    case "2":
                        this.AddGrade(2);
                        break;
                    case "+2":
                    case "2+":
                        this.AddGrade(2.25f);
                        break;
                    case "-3":
                    case "3-":
                        this.AddGrade(2.75f);
                        break;
                    case "3":
                        this.AddGrade(3);
                        break;
                    case "+3":
                    case "3+":
                        this.AddGrade(3.25f);
                        break;
                    case "-4":
                    case "4-":
                        this.AddGrade(3.75f);
                        break;
                    case "4":
                        this.AddGrade(4);
                        break;
                    case "+4":
                    case "4+":
                        this.AddGrade(4.25f);
                        break;
                    case "-5":
                    case "5-":
                        this.AddGrade(4.75f);
                        break;
                    case "5":
                        this.AddGrade(5);
                        break;
                    case "+5":
                    case "5+":
                        this.AddGrade(5.25f);
                        break;
                    case "-6":
                    case "6-":
                        this.AddGrade(5.75f);
                        break;
                    case "6":
                        this.AddGrade(6);
                        break;
                    default:
                        throw new Exception("No to jest po prostu niemozliwe! Nie ma opcji, zebys sie tu znalazl. Cos ty chlopie wprowadzil?");
                }
            }
            else if (!float.TryParse(grade, out float result))
            {
                throw new Exception("Wprowadziles niewlasciwy ciag znakow.");
            }
            else
            {
                result = float.Parse(grade);
                this.AddGrade(result);
            }
        }

        // Dodawanie ocen przy pomocy liczb ulamkowych np. 3.75
        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new Exception("Sorry-Gregory, dane spoza zakresu walidacji. Tylko od 1 do 6.");
            }
        }

        // Dodawanie ocen przy pomocy literek: A - F.
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
                    throw new Exception("No to jest po prostu niemozliwe! Nie ma opcji, zebys sie tu znalazl. Cos ty chlopie wprowadzil?");
            }
        }

        // Dodawanie ocen przy pomocy liczb calkowitych
        public override void AddGrade(int grade)
        {
            float result = (float)grade;
            this.AddGrade(result);
        }

        // Wyliczanie oceny koncowej dla studenta
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
                throw new Exception("Brak ocen.");
            }
        }
    }
}
// Koniec i bomba.
// A kto dotad doczytal, ten traba.