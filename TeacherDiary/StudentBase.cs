namespace TeacherDiary
{
    public abstract class StudentBase : IStudent
    {
        public char[] specialLetters = { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f' };
        public string[] specialGrades = { "+1", "1+", "-2", "2-", "+2", "2+", "-3", "3-", "+3", "3+", "-4", "4-", "+4", "4+", "-5", "5-", "+5", "5+", "-6", "6-" };

        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public abstract void AddGrade(float grade);

        public void AddGrade(string grade)
        {
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
                        throw new Exception("Cos ty za znak chlopie wprowadzil?");
                }
            }
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
                        throw new Exception("Niemozliwe! Nie ma opcji, zebys sie tu znalazl.");
                }
            }
            else if (float.TryParse(grade, out float result))
            {
                result = float.Parse(grade);
                this.AddGrade(result);
            }
            else
            {
                throw new Exception("Wprowadziles niewlasciwy ciag znakow.");
            }
        }

        public abstract Statistics GetStatistics();
    }
}